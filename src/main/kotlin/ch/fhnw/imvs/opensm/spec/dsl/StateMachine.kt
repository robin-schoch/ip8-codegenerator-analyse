package ch.fhnw.imvs.opensm.spec.dsl

import kotlinx.serialization.Serializable


@Serializable
data class StateMachine(
    val initialState: String,
    val states: List<String>,
    val events: List<String>,
    val effects: List<String>
)
