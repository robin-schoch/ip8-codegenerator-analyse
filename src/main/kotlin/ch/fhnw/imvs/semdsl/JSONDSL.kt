package json.dsl

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

typealias ActionId = String

@Serializable
data class Action(
    val id: ActionId,
    val name: String,
    val description: String,
    val hardcoded: Boolean,
    val parameters: List<ParameterId>,
    val constraints: List<List<String>>
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

typealias ConditionId = String

@Serializable
data class Condition(
    val id: ConditionId,
    val left: PropertyId,
    val operator: String,
    val right: PropertyId,
    val name: String
)

typealias DisjunctionId = String

@Serializable
data class Disjunction(
    val id: DisjunctionId,
    val name: String,
    val terms: List<String>
)

typealias ConjunctionId = String

@Serializable
data class Conjunction(
    val id: ConditionId,
    val name: String,
    val terms: List<String>
)

typealias PropertyId = String

@Serializable
data class Property(
    val id: PropertyId,
    val name: String,
    val hardcoded: Boolean,
    val source: String,
    val type: String,
    val unit: String? = null,
    // val value: String? = null
)

@Serializable
data class ParameterWithProperty(
    val parameter: ParameterId,
    val property: PropertyId
)
typealias InvocationId = String

@Serializable
data class Invocation(
    val id: InvocationId,
    val parameters: List<ParameterWithProperty>,
    val action: ActionId,
    val name: String
)

typealias EventId = String

@Serializable
data class Event(
    val id: EventId,
    val check: String
)

typealias StateId = String

@Serializable
data class State(
    val id: StateId,
    val name: String,
    val description: String,
    val invocations: List<InvocationId>
) {
    val cleanName = name.replace(Regex("[^a-zA-Z\\d_]"), "_")
}

typealias TransitionId = String

@Serializable
data class Transition(
    val id: TransitionId,
    val event: EventId,
    val invocations: List<InvocationId>,
    val source: StateId,
    val target: StateId?
)

typealias StateMachineId = String

@Serializable
data class StateMachine(
    val id: StateMachineId,
    val name: String,
    val states: List<StateId>,
    val events: List<EventId>,
    val initialState: StateId
)

@Serializable
data class Type(
    val id: String,
    val type: String
)