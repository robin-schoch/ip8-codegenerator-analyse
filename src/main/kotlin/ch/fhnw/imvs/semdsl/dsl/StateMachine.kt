package ch.fhnw.imvs.semdsl.dsl

import kotlinx.serialization.Serializable

typealias StateMachineId = String

@Serializable
data class StateMachine(
    val id: StateMachineId,
    val name: String,
    val states: List<StateId>,
    val events: List<EventId>,
    val initialState: StateId
)
