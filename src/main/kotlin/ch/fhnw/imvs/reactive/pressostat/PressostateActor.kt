package ch.fhnw.imvs.reactive.pressostat

import ch.fhnw.imvs.reactive.*
import ch.fhnw.imvs.reactive.message.AnimalMessage
import ch.fhnw.imvs.reactive.message.Message
import kotlinx.coroutines.coroutineScope


data class PressostatState(
    val debounceDuration: Second = 2,
    val maximumDuration: Minute = 10,
    val overpressureCount: Int = 20,
    val maximumPauseDuration: Minute = 30,
    val maximumActiveDuration: Hour = 100,
    val maximumPauseCount: Int = 23,
) : ActorState


class PressostatActor() : Actor<PressostatState> {
    override lateinit var state: PressostatState

    context(Dispatcher) override suspend fun modifyState(message: Message): PressostatState? {
        return when (message) {
            is TimeNowMessage -> state.copy(maximumDuration = state.maximumDuration + 1)
            is AnimalMessage -> {
                println("Animal message: ${message.animal}")
                return null
            }

            else -> null
        }
    }

    context(Dispatcher)override suspend fun update(state: PressostatState) {
        coroutineScope {
            when (state.debounceDuration) {
                state.maximumDuration % 10 -> {
                    println("check pressostat")
                    dispatchAsync(AnimalMessage("dog"))
                }

                else -> {}
            }
        }
    }

    context(Dispatcher) override fun setup() {
        state = PressostatState()
    }


}
