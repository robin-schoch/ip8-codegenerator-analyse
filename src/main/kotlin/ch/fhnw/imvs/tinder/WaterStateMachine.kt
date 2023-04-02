package ch.fhnw.imvs.tinder

import com.tinder.StateMachine

sealed class BridgeState {
    data object Open : BridgeState()
    data object Closed : BridgeState()
}

sealed class BridgeEvent {
    data object OnClose : BridgeEvent()
    data object OnOpen : BridgeEvent()
}

sealed class BridgeEffect {
    data object ChangeTrafficLightToRed : BridgeEffect()
    data object ChangeTrafficLightToGreen : BridgeEffect()
}

val BridgeMachine = StateMachine.create<BridgeState, BridgeEvent, BridgeEffect> {
    initialState(BridgeState.Open)
    state<BridgeState.Open> {
        on<BridgeEvent.OnClose> {
            TODO()
            transitionTo(BridgeState.Closed, BridgeEffect.ChangeTrafficLightToRed)
        }
    }
    state<BridgeState.Closed> {
    }
    onTransition {
        val validTransition = it as? StateMachine.Transition.Valid ?: return@onTransition
        validTransition.sideEffect?.let { effect ->
            when (effect) {
                BridgeEffect.ChangeTrafficLightToRed -> TODO()
                BridgeEffect.ChangeTrafficLightToGreen -> TODO()
            }
        }
    }
}

fun main() {

}