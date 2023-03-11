package ch.fhnw.imvs.opensm.core.model

enum class PrimitiveTyp {
    INTEGER, STRING, BOOLEAN;

    companion object {
        fun of(v: String) = when (v.lowercase()) {
            "integer" -> PrimitiveTyp.INTEGER
            "string" -> PrimitiveTyp.STRING
            "boolean" -> PrimitiveTyp.BOOLEAN
            else -> error("unsupported primitive type")
        }
    }
}

class GenModel(
    var stateMachines: List<GenStateMachine>
)

class GenStateMachine(
    var name: String,
    var initial: GenState,
    var states: List<GenState>,
    var events: List<GenEvent>,
    var effects: List<GenEffect>,
    var machineState: String = "$name State",
    var machineTransition: String = "$name Transition",
    var machineEvent: String = "$name Event",
    var machineEffect: String = "$name Effect",
)

class GenState(
    var name: String,
    var machine: String,
    var transitions: List<GenTransition>,
    var parameters: List<GenParameter>,
    var machineState: String = "$machine State",
    var hasParameters: Boolean = parameters.isNotEmpty()
)

class GenEffect(
    var name: String,
    var machine: String,
    var machineEffect: String = "$machine Effect"
)

class GenParameter(
    var name: String,
    var type: String,
    var default: String
)

class GenTransition(
    var event: GenEvent,
    var machine: String,
    var target: GenState,
    var effect: GenEffect?,
    var machineTransition: String = "$machine Transition",
    var machineEffect: String = "$machine Effect",
)

class GenEvent(
    var name: String,
    var machine: String,
    var parameters: List<GenParameter>,
    var machineEvent: String = "$machine Event",
    var hasParameters: Boolean = parameters.isNotEmpty()
)

