package ch.fhnw.imvs.semdsl.stage2

import ch.fhnw.imvs.semdsl.dsl.*

object Context {
    fun properties(): GeneratedProperties = GeneratedProperties(registryElements.map { it.value }.toList())

    val inlineElements: MutableMap<String, String> = mutableMapOf()

    val registryElements: MutableMap<String, String> = mutableMapOf()

    val actionContext: MutableMap<String, (List<String>) -> String> = mutableMapOf()
    
    val transitionContext: MutableMap<String, List<() -> List<String>>> = mutableMapOf()

    val eventContext: MutableMap<String, GeneratedEvent> = mutableMapOf()

    val stateContext: MutableMap<String, String> = mutableMapOf()

    val fullStateContext: MutableMap<String, GeneratedState> = mutableMapOf()
    fun registerAction(actions: List<Action>) {
        actions.forEach { actionContext[it.id] = { variables -> it.use(variables) } }
    }

    fun registerTerm(conditions: List<ParseableTerm>) {
        val parsedTerms = inlineElements.keys.toMutableSet()
        var leftToParse = conditions
        while (leftToParse.isNotEmpty()) {
            val nextToParse = mutableListOf<ParseableTerm>()
            for (term in leftToParse) {
                if (term.allDependencyParsed(parsedTerms)) {
                    GeneratedTerm.of(term).also {
                        parsedTerms.add(it.hash)
                        inlineElements[it.hash] = it.inline
                    }
                } else {
                    nextToParse.add(term)
                }
            }
            leftToParse = nextToParse
        }
    }

    fun registerProperties(properties: List<Property>) {
        val parsedInlineElements = inlineElements.keys.toMutableSet()
        var leftToParseProperties = properties
        while (leftToParseProperties.isNotEmpty()) {
            val nextToParse = mutableListOf<Property>()
            for (property in properties) {
                if (property.allDependencyParsed(parsedInlineElements)) {
                    GeneratedProperty(property.id, property.use(), property.registryDeclaration()).also {
                        inlineElements[it.hash] = it.use
                        registryElements[it.hash] = it.definition
                        parsedInlineElements.add(it.hash)
                    }
                } else {
                    nextToParse.add(property)
                }
            }
            leftToParseProperties = nextToParse
        }
    }

    fun registerInvocation(invocations: List<Invocation>) {
        val parsedInlineElements = inlineElements.keys.toMutableSet()
        var leftToParseInlineElements = invocations
        while (leftToParseInlineElements.isNotEmpty()) {
            val nextToParse = mutableListOf<Invocation>()
            for (invocation in invocations) {
                if (invocation.allDependencyParsed(parsedInlineElements)) {
                    actionContext[invocation.action]!!(invocation.parameters.map {
                        inlineElements[it.property] ?: error(
                            "element ${it.property} does not exist"
                        )
                    }).also {
                        inlineElements[invocation.id] = it
                        parsedInlineElements.add(invocation.id)
                    }
                } else {
                    nextToParse.add(invocation)
                }
            }
            leftToParseInlineElements = nextToParse
        }
    }


    fun registerEvents(events: List<Event>) {
        events.mapIndexed { index, event ->
            val name = "Event$index()"
            GeneratedEvent(event.id, name, event.use(name))
        }.forEach { eventContext[it.hash] = it }
    }

    fun registerStates(states: List<State>) {
        states.forEach {
            stateContext[it.id] = it.cleanName
        }
        with(Context) {
            states.map {
                GeneratedState(
                    it.id,
                    it.cleanName,
                    it.inlineInvocations(),
                    (transitionContext[it.id] ?: listOf()).map { it() }.filter { it.isNotEmpty() }
                )
            }.forEach { fullStateContext[it.hash] = it }
        }
    }

    fun registerTransitions(transition: List<Transition>) {
        transition.forEach {
            transitionContext.computeIfAbsent(it.source) { _ -> listOf() }
            transitionContext.computeIfPresent(it.source) { _, list -> list + listOf({ it.use() }) }
        }
    }

    fun registerStatemachine(machine: List<StateMachine>): List<GeneratedStateMachine> {
        return machine.map {
            GeneratedStateMachine(
                it.name,
                it.states.mapNotNull { s -> fullStateContext[s] }.toList(),
                it.events.mapNotNull { e -> eventContext[e] }.toList(),
                fullStateContext[it.initialState]!!
            )
        }.toList()
    }
}

data class GeneratedProperties(val properties: List<String>)
data class GeneratedProperty(val hash: String, val use: String, val definition: String)

data class GeneratedState(
    val hash: String,
    val name: String,
    val stateTransition: String,
    val transitions: List<List<String>>
)

data class GeneratedTerm(val hash: String, val inline: String) {
    companion object {
        fun of(term: ParseableTerm): GeneratedTerm =
            with(Context) {
                GeneratedTerm(term.id, term.use())
            }

    }
}

data class GeneratedEvent(val hash: String, val use: String, val definition: List<String>)

data class GeneratedStateMachine(
    val name: String,
    val states: List<GeneratedState>,
    val events: List<GeneratedEvent>,
    val initialState: GeneratedState
)