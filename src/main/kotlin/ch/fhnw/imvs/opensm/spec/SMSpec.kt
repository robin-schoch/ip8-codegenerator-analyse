package ch.fhnw.imvs.opensm.spec


import ch.fhnw.imvs.opensm.spec.dsl.*
import kotlinx.serialization.Serializable


@Serializable
data class SMSpec(
    val version: String,
    val stateMachines: Map<String, StateMachine>,
    val states: Map<String, State>,
    val events: Map<String, Event>,
    val transitions: Map<String, Transition>,
    val effects: Map<String, Effect>,
    val parameters: Map<String, Parameter>
)
