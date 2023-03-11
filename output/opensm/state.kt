import com.tinder.StateMachine


sealed class WaterModelState {
     object Liquide : WaterModelState()
    data class Frozen(val temperatur : Int = 18, val label : String = "no label", ) : WaterModelState()

}

sealed class WaterModelEvent {
    object OnMelted : WaterModelEvent()
    data class OnFrozen(val temperatur : Int = 18, val label : String = "no label", ) : WaterModelEvent()

}

sealed class WaterModelEffect {
    object LogMelting : WaterModelEffect()
    object LogAccident : WaterModelEffect()
    object LogFreeze : WaterModelEffect()
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
        when (validTransition.sideEffect) {
            WaterModelEffect.LogMelting -> TODO()
            WaterModelEffect.LogAccident -> TODO()
            WaterModelEffect.LogFreeze -> TODO()
            else -> error("unsupported effect")
        }
    }
}
