package ch.fhnw.imvs.semdsl.stage1

import ch.fhnw.imvs.semdsl.EventWithName
import ch.fhnw.imvs.semdsl.Generator
import ch.fhnw.imvs.semdsl.StateWithTransition
import ch.fhnw.imvs.semdsl.dsl.JSONDSL
import ch.fhnw.imvs.semdsl.dsl.State
import ch.fhnw.imvs.semdsl.dsl.StateMachine
import com.github.mustachejava.DefaultMustacheFactory
import java.io.File

object CSharpJsonGenerator : Generator {

    private val mustacheFactory by lazy { DefaultMustacheFactory() }

    lateinit var stateMachines: List<ch.fhnw.imvs.semdsl.StateMachineEnriched>
    override fun initialise(dsl: JSONDSL) {
        val eventMap = dsl.stateMachines.associateWith { machine ->
            machine.events
                .map { id -> dsl.events.find { it.id == id }!! }
                .mapIndexed { index, event -> EventWithName(event, "event$index") }
        }
        val eventIdToFunctionName = eventMap.values.flatten().associate { it.event.id to it.name }
        val transitionToTarget = dsl.transitions
            .map {
                it.copy(
                    event = eventIdToFunctionName[it.event]!!,
                    target = dsl.states.find { s -> it.target == s.id }?.cleanName
                )
            }
            .filter { it.invocations.isNotEmpty() }
            .groupBy { it.source }

        val stateMap = dsl.stateMachines.associateWith { machine ->
            machine.states
                .map { id -> dsl.states.find { it.id == id }!! }
                .map { StateWithTransition(it, transitionToTarget[it.id] ?: listOf()) }
        }

        stateMachines =
            dsl.stateMachines.map { ch.fhnw.imvs.semdsl.StateMachineEnriched(it, stateMap[it]!!, eventMap[it]!!) }
    }

    override fun generateRegistry(mustacheTemplatePath: String, outputDir: String) {

    }

    override fun generateStateMachines(mustacheTemplatePath: String, outputDir: String, machines: Set<String>) {
        stateMachines.forEach { data ->
            println("hallo")
            val mustacheTemplate = mustacheFactory.compile(mustacheTemplatePath)
            File(outputDir).mkdirs()
            File("$outputDir/${data.machine.name}JsonMachine.cs").bufferedWriter()
                .use { mustacheTemplate.execute(it, data) }
        }

    }

    override fun listMachines(): Set<String> {
        return stateMachines.map { it.machine.name }.toSet()
    }

    data class StateMachineEnriched(
        val machine: StateMachine,
        val states: List<StateWithTransition>,
        val events: List<EventWithName>,
        val initialState: State = states.find { it.state.id == machine.initialState }!!.state
    )
}