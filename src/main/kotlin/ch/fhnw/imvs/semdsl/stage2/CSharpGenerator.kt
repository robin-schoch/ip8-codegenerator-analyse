package ch.fhnw.imvs.semdsl.stage2

import ch.fhnw.imvs.semdsl.Generator
import ch.fhnw.imvs.semdsl.dsl.JSONDSL
import ch.fhnw.imvs.semdsl.dsl.StateMachine
import com.github.mustachejava.DefaultMustacheFactory
import java.io.File

object CSharpGenerator : Generator {

    private val mustacheFactory by lazy { DefaultMustacheFactory() }

    private val _registry: MutableMap<String, RegistryItem> = mutableMapOf()
    val registry: RegistryItems
        get() = _registry.toMap()

    private val _inlineItems: MutableMap<String, InlineItem> = mutableMapOf()
    val inlineItems: InlineItems
        get() = _inlineItems.toMap()

    private val _transitionItems: MutableMap<String, List<TransitionItem>> = mutableMapOf()

    val transitionItems: TransitionItems
        get() = _transitionItems.toMap()

    private val _stateMachineItems: MutableMap<String, StateMachineItem> = mutableMapOf()

    val stateMachineItems: StateMachineItems
        get() = _stateMachineItems.toMap()

    private val _stateMachines: MutableMap<String, StateMachineData> = mutableMapOf()

    val stateMachines: Map<String, StateMachineData>
        get() = _stateMachines.toMap()


    override fun initialise(dsl: JSONDSL) {
        with(dsl) {
            addRegistryItems(properties)
            addInlineItems(properties + actions + conditions + conjunctions + disjunctions + events + states + invocations)
            addStateMachineItems(states + events + transitions)
            addTransitionItems(transitions)
            addStateMachines(stateMachines)
        }
    }

    override fun generateRegistry(mustacheTemplatePath: String, outputDir: String) {
        val compiledTemplate = mustacheFactory.compile(mustacheTemplatePath)
        File(outputDir).mkdirs()
        File("$outputDir/registry.cs").bufferedWriter()
            .use { compiledTemplate.execute(it, RegistryTemplate(registry.values)) }
    }


    fun generateStateMachine(
        stateMachineTemplate: StateMachineTemplate,
        mustacheTemplatePath: String,
        outputDir: String
    ) {
        val compiledTemplate = mustacheFactory.compile(mustacheTemplatePath)
        File(outputDir).mkdirs()
        File("$outputDir/${stateMachineTemplate.name}.cs").bufferedWriter()
            .use { compiledTemplate.execute(it, stateMachineTemplate) }
    }

    override fun generateStateMachines(mustacheTemplatePath: String, outputDir: String, machines: Set<String>) {
        stateMachines.values.filter { machines.contains(it.name) }.map { StateMachineTemplate(it) }.forEach {
            generateStateMachine(it, mustacheTemplatePath, outputDir)
        }
    }

    override fun listMachines(): Set<String> {
        return this.stateMachines.values.map { it.name }.toSet()
    }

    private fun addRegistryItems(items: List<RegistrableItem>) {
        items.forEach { _registry[it.getKey()] = it.buildEntry() }
    }

    private fun addInlineItems(items: List<InlineableItem>) {
        items.forEach { _inlineItems[it.getKey()] = it.buildCall() }
    }

    private fun addStateMachineItems(items: List<StateMachinableItem>) {
        items.forEach { _stateMachineItems[it.getKey()] = it.buildStateMachineEntry() }
    }

    private fun addStateMachines(items: List<StateMachine>) {
        items.forEach {
            _stateMachines[it.id] = StateMachineData.of(it)
        }
    }

    private fun addTransitionItems(items: List<TransitionableItem>) {
        items.forEach {
            val item = it.buildTransition()
            _transitionItems.compute(item.transition) { _, value -> (value ?: listOf()) + listOf(item) }
        }
    }

    data class RegistryTemplate(val items: Iterable<RegistryItem>) {
        val registryEntries = items.map { it.entry(inlineItems) }
    }

    data class StateMachineTemplate(val stateMachine: StateMachineData) {


        val initialState = (stateMachineItems[stateMachine.initialState] ?: error("Initial State is missing"))
            .definition(inlineItems, stateMachineItems)

        val name = stateMachine.name

        val events = stateMachine.events.map { stateMachineItems[it] ?: error("Event is missing") }
            .map { it.definition(inlineItems, stateMachineItems) }

        val statesDefinition = stateMachine.states.map { stateMachineItems[it] ?: error("State is missing") }
            .map { it.definition(inlineItems, stateMachineItems).first() }

        val stateTransition = stateMachine.states.map { TransitionTemplate(it) }

        /*



         */
    }

    data class TransitionTemplate(val state: String) {

        val stateName = stateMachineItems[state]?.definition?.let { it(inlineItems, stateMachineItems) }?.first()
            ?: error("Missing from state")

        val defaultInvocation = inlineItems[state]?.let { it.call(inlineItems, listOf()) } ?: ""

        val transitions = (transitionItems[state] ?: listOf())
            .map { stateMachineItems[it.hash] ?: error("Missing transition") }
            .map { it.definition(inlineItems, stateMachineItems) }

    }

}

data class StateMachineData(
    val hash: String,
    val name: String,
    val initialState: String,
    val states: List<String>,
    val events: List<String>
) {

    companion object {
        fun of(machine: StateMachine): StateMachineData {
            return StateMachineData(machine.id, machine.name, machine.initialState, machine.states, machine.events)
        }
    }
}

