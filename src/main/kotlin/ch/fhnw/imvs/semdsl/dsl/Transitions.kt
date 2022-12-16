package ch.fhnw.imvs.semdsl.dsl

import kotlinx.serialization.Serializable


typealias TransitionId = String

@Serializable
data class Transition(
    val id: TransitionId,
    val event: EventId,
    val invocations: List<InvocationId>,
    val source: StateId,
    val target: StateId?
)

