package ch.fhnw.imvs.reactive2

import ch.fhnw.imvs.reactive2.dispatcher.system
import kotlin.time.Duration


fun main() {
    val timer = timer("Timer 1") {}
    val timer2 = timer("Timer 2") {}

    system {

        on {
            message = RunSystem::class
            action = timer::start
        }
        onWithParameter<Duration> {
            message = RunSystem::class
            map = { Duration.parse("1s") }
            action = timer2::start
        }
        on {
            message = TimerEnded::class
            filter = { message -> message.source == timer2.name }
            action = timer::start
        }
        on {
            message = TimerEnded::class
            filter = { message -> message.source == timer.name }
            action = timer2::start
        }
    }.start()
}
