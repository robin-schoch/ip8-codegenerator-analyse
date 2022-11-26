package ch.fhnw.imvs.reactive

import ch.fhnw.imvs.reactive.message.Message
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.channels.Channel.Factory.UNLIMITED
import kotlinx.coroutines.flow.MutableSharedFlow
import kotlinx.coroutines.flow.asSharedFlow
import kotlinx.coroutines.launch

object Dispatcher {

    private val _messageStream = MutableSharedFlow<Message>(UNLIMITED)

    val messages = _messageStream.asSharedFlow()

    suspend fun dispatch(message: Message) {
        _messageStream.emit(message)
    }

}

context(Dispatcher)
fun CoroutineScope.dispatchAsync(message: Message) = launch { dispatch(message) }
