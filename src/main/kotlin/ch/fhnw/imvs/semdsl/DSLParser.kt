package ch.fhnw.imvs.semdsl


import json.dsl.*
import kotlinx.serialization.ExperimentalSerializationApi
import kotlinx.serialization.json.Json
import kotlinx.serialization.json.decodeFromStream

class DSLParser(path: String) {

    private val json = Json { ignoreUnknownKeys = true }

    @OptIn(ExperimentalSerializationApi::class)
    private val dsl: JSONDSL by lazy {
        with(javaClass.classLoader.getResourceAsStream(path)) { json.decodeFromStream(this!!) }
    }

    val stateMachines: List<StateMachineEnriched> by lazy {
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

        dsl.stateMachines.map { StateMachineEnriched(it, stateMap[it]!!, eventMap[it]!!) }.also { println(it) }
    }

}

data class StateMachineEnriched(
    val machine: StateMachine,
    val states: List<StateWithTransition>,
    val events: List<EventWithName>,
    val initialState: State = states.find { it.state.id == machine.initialState }!!.state
)

data class EventWithName(
    val event: Event,
    val name: String
)

data class StateWithTransition(
    val state: State,
    val transitions: List<Transition>
)