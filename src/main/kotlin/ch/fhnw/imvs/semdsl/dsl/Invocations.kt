package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.dsl.ActionsTypes.Companion.findActionType
import kotlinx.serialization.Serializable

typealias InvocationId = String


@Serializable
data class Invocation(
    val id: InvocationId,
    val parameters: List<ParameterWithProperty>,
    val action: ActionId,
    val name: String
) {

    fun invocationStatement(): String {
        return when (findActionType(action)!!) {
            is ActionsTypes.InvokeIf -> ""
            ActionsTypes.Add -> TODO()
            ActionsTypes.Assign -> TODO()
            ActionsTypes.CloseInletAirBypassValve -> TODO()
            ActionsTypes.CloseReservoirBypassValve -> TODO()
            ActionsTypes.Decrement -> TODO()
            ActionsTypes.EnsureOffCompressor -> TODO()
            ActionsTypes.EnsureOnCompressor -> TODO()
            ActionsTypes.OpenInletAirBypassValve -> TODO()
            ActionsTypes.OpenReservoirBypassValve -> TODO()
            ActionsTypes.ReduceMaximumTemperatureReservoirTemperatureRangeService -> TODO()
            ActionsTypes.StartTimerActionHandler -> TODO()
            ActionsTypes.StopAndResetTimerActionHandler -> TODO()
            ActionsTypes.Subtract -> TODO()
            ActionsTypes.Zero -> TODO()
            ActionsTypes.Increment -> "++"
        }
    }


}