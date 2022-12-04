package ch.fhnw.imvs.semdsl.dsl

import kotlinx.serialization.Serializable

typealias ActionId = String

sealed class ActionsTypes {
    abstract val actionId: ActionId


    fun mapEntry() = actionId to this

    companion object {
        private val all = mapOf(
            Assign.mapEntry(),
            Zero.mapEntry(),
            Decrement.mapEntry(),
            Add.mapEntry(),
            Subtract.mapEntry(),
            InvokeIf.mapEntry(),
            EnsureOnCompressor.mapEntry(),
            EnsureOffCompressor.mapEntry(),
            OpenInletAirBypassValve.mapEntry(),
            CloseInletAirBypassValve.mapEntry(),
            OpenReservoirBypassValve.mapEntry(),
            CloseReservoirBypassValve.mapEntry(),
            StartTimerActionHandler.mapEntry(),
            StopAndResetTimerActionHandler.mapEntry(),
            ReduceMaximumTemperatureReservoirTemperatureRangeService.mapEntry(),
        )

        fun findActionType(id: ActionId) = all[id]
    }


    data object Assign : ActionsTypes() {
        override val actionId = "cb77de99-4505-4c18-b05c-77e2c02beb24"
    }

    data object Zero : ActionsTypes() {
        override val actionId = "51514694-20e7-42f3-a7f0-63f73c38e3a9"
    }

    data object Increment : ActionsTypes() {
        override val actionId = "41a3a297-d0bc-4d2f-99de-d202509602b0"
    }

    data object Decrement : ActionsTypes() {
        override val actionId = "ec7e4575-01ef-4e23-a46c-805615255b61"
    }

    data object Add : ActionsTypes() {
        override val actionId = "caf92d53-79fd-414b-84cf-9d9d9475ff76"
    }

    data object Subtract : ActionsTypes() {
        override val actionId = "d1551641-1941-457d-98f2-37baa327d23a"
    }

    data object InvokeIf : ActionsTypes() {
        override val actionId = "6271ba44-0068-407b-ad14-b665a83136e0"
    }

    data object EnsureOnCompressor : ActionsTypes() {
        override val actionId = "59c91b75-6faa-4caf-aab5-dc2222df39da"
    }

    data object EnsureOffCompressor : ActionsTypes() {
        override val actionId = "6f12dda9-5b01-4139-8fc6-f88114f78bbe"
    }

    data object OpenInletAirBypassValve : ActionsTypes() {
        override val actionId = "e3ac8e13-81e6-4c40-b6e8-f43eeb90678c"
    }

    data object CloseInletAirBypassValve : ActionsTypes() {
        override val actionId = "5811a09a-9ea4-4bfb-9419-e57c7c9804eb"
    }

    data object OpenReservoirBypassValve : ActionsTypes() {
        override val actionId = "f3708d7f-b014-4c47-8871-76b83232e611"
    }

    data object CloseReservoirBypassValve : ActionsTypes() {
        override val actionId = "37b56414-17ef-4486-af60-6758b4449487"
    }

    data object StartTimerActionHandler : ActionsTypes() {
        override val actionId = "82fe2d8c-4750-4057-a988-c187738aa678"
    }

    data object StopAndResetTimerActionHandler : ActionsTypes() {
        override val actionId = "f76b75ae-dbee-4c45-aba0-b287b9edcf5b"
    }

    data object ReduceMaximumTemperatureReservoirTemperatureRangeService : ActionsTypes() {
        override val actionId = "5ac89853-9983-455f-9cf5-afd9eaef51c0"
    }


}


@Serializable
data class Action(
    val id: ActionId,
    val name: String,
    val description: String,
    val hardcoded: Boolean,
    val parameters: List<ParameterId>,
    val constraints: List<List<String>>
)
