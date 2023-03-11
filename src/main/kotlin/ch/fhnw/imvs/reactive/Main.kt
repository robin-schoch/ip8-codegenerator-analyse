package ch.fhnw.imvs.reactive

import ch.fhnw.imvs.reactive.message.AnimalMessage
import ch.fhnw.imvs.reactive.message.HumanMessage
import ch.fhnw.imvs.reactive.message.Message
import ch.fhnw.imvs.reactive.pressostat.PressostatActor
import kotlinx.coroutines.flow.Flow
import kotlinx.coroutines.launch
import kotlinx.coroutines.runBlocking

fun main() {
    val presso: PressostatActor
    val timer: TimerActor
    with(Dispatcher) {
        presso = PressostatActor()
        timer = TimerActor(TimerState(1000))
    }
    val a = listOf(1, 2, 3, 4)
    'a' to 'b'
    for (v in a) {
        println(v)
    }

    runBlocking {
        listOf(launch { presso.start() }, launch { timer.start() })
        launch {
            with(Dispatcher) {
                dispatchAsync(AnimalMessage("bird"))
                dispatchAsync(AnimalMessage("dog"))
                dispatchAsync(AnimalMessage("fish"))
            }
        }
    }

}


class ActorOne(private val messageFlow: Flow<Message>) {

    var state: ActorOneState = ActorOneState(20, 0, "")

    suspend fun start() {
        messageFlow.collect {
            modifyState(it)
        }
    }

    private fun modifyState(message: Message) {
        when (message) {
            is AnimalMessage -> state = state.copy(temperature = state.temperature + 10)
            is HumanMessage -> state = state.copy(temperature = state.temperature + 3)
        }
    }


}

data class ActorOneState(val temperature: Int, val screamCount: Int, val lastScream: String)

