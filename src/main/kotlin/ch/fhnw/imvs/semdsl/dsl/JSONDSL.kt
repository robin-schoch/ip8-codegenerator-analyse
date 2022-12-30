package ch.fhnw.imvs.semdsl.dsl

import kotlinx.serialization.Serializable


@Serializable
data class JSONDSL(
    val version: String,
    val actions: List<Action>,
    val conjunctions: List<Conjunction>,
    val conditions: List<Condition>,
    val events: List<Event>,
    val disjunctions: List<Disjunction>,
    val invocations: List<Invocation> = listOf(),
    val parameters: List<Parameters>,
    val properties: List<Property>,
    val states: List<State>,
    val transitions: List<Transition>,
    val stateMachines: List<StateMachine>,
    val types: List<Type>,
)

typealias ParameterId = String

@Serializable
data class Parameters(
    val id: ParameterId,
    val type: String,
    val name: String,
    val units: List<String>,
    val sources: List<String>

)


@Serializable
data class ParameterWithProperty(
    val parameter: ParameterId,
    val property: PropertyId
)


typealias StateMachineId = String


@Serializable
data class Type(
    val id: String,
    val type: String
)