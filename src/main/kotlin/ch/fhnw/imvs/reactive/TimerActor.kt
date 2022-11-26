package ch.fhnw.imvs.reactive

import ch.fhnw.imvs.reactive.message.Message
import kotlinx.coroutines.*
import kotlinx.coroutines.channels.produce
import java.time.LocalDateTime

data class TimerState(val interval: Second) : ActorState

data class TimeNowMessage(val now: LocalDateTime = LocalDateTime.now()) : Message

@OptIn(ExperimentalCoroutinesApi::class)
class TimerActor(override var state: TimerState) : Actor<TimerState> {

    context(Dispatcher) override suspend fun modifyState(message: Message): TimerState? = null

    context(Dispatcher) override suspend fun update(state: TimerState) {}

    context(Dispatcher) override fun setup() {
        CoroutineScope(Dispatchers.IO).launch {
            val timer = timer()
            launch {
                for (time in timer) {
                    dispatchAsync(TimeNowMessage())
                }
            }
        }
    }

    private fun CoroutineScope.timer() = produce<LocalDateTime> {
        while (true) {
            send(LocalDateTime.now())
            delay(state.interval)
        }
    }
}