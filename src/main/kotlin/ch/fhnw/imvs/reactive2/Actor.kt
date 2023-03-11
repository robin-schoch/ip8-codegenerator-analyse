package ch.fhnw.imvs.reactive2


import ch.fhnw.imvs.reactive2.dispatcher.dispatchMessage
import kotlinx.coroutines.coroutineScope
import kotlinx.coroutines.delay
import kotlinx.coroutines.launch
import kotlinx.datetime.Clock
import kotlinx.datetime.LocalDateTime
import kotlinx.datetime.TimeZone
import kotlinx.datetime.toLocalDateTime
import kotlin.time.Duration

interface ActorState
interface Actor<T : ActorState> {
    val name: String
    var state: T
}

data class TimerState(
    val isRunning: Boolean,
    val startTime: LocalDateTime?,
    val endTime: LocalDateTime?,
    val duration: Duration?
) : ActorState

fun timer(name: String, init: Actor<TimerState>.() -> Unit): Timer {
    val timer = Timer(name)
    timer.init()
    return timer
}

class Timer(override val name: String) : Actor<TimerState> {

    override var state: TimerState = TimerState(false, null, null, null)

    suspend fun start(duration: Duration): Unit {
        coroutineScope {
            launch {
                delay(duration)
                dispatchMessage(TimerEnded(this@Timer.name))
                println("[$name]: $duration done ${Clock.System.now().toLocalDateTime(TimeZone.UTC)}")
            }
        }
    }

    suspend fun start() = start(Duration.parse("5s"))
}
