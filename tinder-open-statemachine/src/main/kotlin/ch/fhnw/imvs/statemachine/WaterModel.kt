import com.tinder.StateMachine

sealed class WaterModelState {
    data object Liquide : WaterModelState()
    data class Frozen(val temperatur : Int = 18, val label : String = "no label", ) : WaterModelState()

}

sealed class WaterModelEvent {
    data object OnMelted : WaterModelEvent()
    data class OnFrozen(val temperatur : Int = 18, val label : String = "no label", ) : WaterModelEvent()

}

sealed class WaterModelEffect {
    data object LogMelting : WaterModelEffect()
    data object LogAccident : WaterModelEffect()
    data object LogFreeze : WaterModelEffect()
}

val WaterModelMachine = StateMachine.create<WaterModelState, WaterModelEvent, WaterModelEffect> {
    initialState(WaterModelState.Liquide)
    state<WaterModelState.Liquide> {
        on<WaterModelEvent.OnFrozen> {
            TODO()
            transitionTo(WaterModelState.Frozen() ,WaterModelEffect.LogFreeze)
        }
    }
    state<WaterModelState.Frozen> {
        on<WaterModelEvent.OnMelted> {
            TODO()
            transitionTo(WaterModelState.Liquide)
        }
    }
    onTransition {
        val validTransition = it as? StateMachine.Transition.Valid ?: return@onTransition
        validTransition.sideEffect?.let { effect ->
            when (effect) {
                WaterModelEffect.LogMelting -> TODO()
                WaterModelEffect.LogAccident -> TODO()
                WaterModelEffect.LogFreeze -> TODO()
            }
        }
    }
}