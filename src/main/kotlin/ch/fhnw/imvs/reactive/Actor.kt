package ch.fhnw.imvs.reactive

import ch.fhnw.imvs.reactive.message.Message

interface ActorState

interface Actor<T : ActorState> {

    var state: T

    suspend fun start() {
        with(Dispatcher) {
            setup()
            messages.collect { message ->
                modifyState(message)?.let {
                    state = it
                    update(it)
                }
            }
        }
    }

    fun filterMessage(message: Message): Boolean = true


    context(Dispatcher)fun setup(): Unit {
    }

    context(Dispatcher) suspend fun modifyState(message: Message): T?

    context(Dispatcher) suspend fun update(state: T)
}