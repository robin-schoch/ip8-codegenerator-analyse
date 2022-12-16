package ch.fhnw.imvs.semdsl.stage2

import ch.fhnw.imvs.semdsl.dsl.*

object Context {

    val propertyContext: MutableMap<String, GeneratedProperty> = mutableMapOf()

    val termContext: MutableMap<String, String> = mutableMapOf()

    val actionContext: MutableMap<String, (List<ParameterWithProperty>) -> String> = mutableMapOf()

    val invocationContext: MutableMap<String, String> = mutableMapOf()

    val eventContext: MutableMap<String, GeneratedEvent> = mutableMapOf()

    fun registerProperties(properties: List<Property>) {
        properties.filter { it.source == PropertySource.VARIABLE }.map {
            GeneratedProperty(it.id, it.use(), it.statement())
        }.forEach { propertyContext[it.hash] = it }
    }

    fun registerAction(actions: List<Action>) {
        actions.forEach { actionContext[it.id] = { vars -> it.use(vars) } }
    }

    fun registerInvocation(invocations: List<Invocation>) {
        invocations
            .map { it.id to actionContext[it.action]!!(it.parameters) }
            .forEach { invocationContext[it.first] = it.second }
    }

    fun registerConditions(conditions: List<Condition>) {

    }

    fun registerEvents(events: List<Event>) {
        events.mapIndexed { index, event ->
            val name = "Event$index()"
            GeneratedEvent(event.id, name, event.use(name))
        }.forEach { eventContext[it.hash] = it }
    }
}

data class GeneratedProperty(val hash: String, val use: String, val definition: String)

data class GeneratedEvent(val hash: String, val use: String, val definition: String)

data class GeneratedState(
    val hash: String,
    val name: String,
    val use: String,
    val definition: (transition: List<Transition>) -> String
)