package ch.fhnw.imvs.reactive2.dispatcher

import ch.fhnw.imvs.reactive2.Message
import ch.fhnw.imvs.reactive2.RunSystem
import ch.fhnw.imvs.reactive2.dispatcher.MessageStream.messageStream
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.channels.Channel
import kotlinx.coroutines.flow.MutableSharedFlow
import kotlinx.coroutines.flow.asSharedFlow
import kotlinx.coroutines.launch
import kotlinx.coroutines.runBlocking
import kotlin.reflect.KClass


typealias ActionFn = (message: Message) -> suspend () -> Unit

object MessageStream {
    val messageStream = MutableSharedFlow<Message>(Channel.UNLIMITED)
}

suspend fun CoroutineScope.dispatchMessage(message: Message) = messageStream.emit(message)

class Dispatcher {

    private val dispatcherFns: MutableMap<KClass<out Message>, List<ActionFn>> = mutableMapOf()

    private val messages
        get() = messageStream.asSharedFlow()


    fun start() {
        runBlocking {
            dispatchMessage(RunSystem())
            messages.collect {
                dispatcherFns.getOrDefault(it::class, listOf()).onEach { fn ->
                    launch { fn(it)() }
                }
            }

        }
    }

    fun on(init: On.() -> Unit): Unit {
        val on = On()
        on.init()
        val fn = { m: Message ->
            suspend {
                if (on.filter(m)) on.action()
            }
        }
        register(on.message, fn)
    }

    fun <T : Any> onWithParameter(init: OnWithParameter<T>.() -> Unit): Unit {
        val on = OnWithParameter<T>()
        on.init()
        val fn = { m: Message ->
            suspend {
                if (on.filter(m)) {

                    on.action(on.map(m))
                }
            }
        }
        register(on.message, fn)
    }

    private fun register(message: KClass<out Message>, fn: ActionFn) {
        dispatcherFns.compute(message) { _, value -> (value ?: listOf()) + fn }
    }

}
