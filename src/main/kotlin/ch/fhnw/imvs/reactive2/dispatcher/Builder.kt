package ch.fhnw.imvs.reactive2.dispatcher

import ch.fhnw.imvs.reactive2.Message
import kotlin.reflect.KClass

fun system(init: Dispatcher.() -> Unit): Dispatcher {
    val dispatcher = Dispatcher()
    dispatcher.init()
    return dispatcher
}

interface OnClause {
    var message: KClass<out Message>
    var filter: ((message: Message) -> Boolean)
}

class On : OnClause {
    override lateinit var message: KClass<out Message>
    lateinit var action: suspend () -> Unit
    override var filter: (message: Message) -> Boolean = { _ -> true }
}

class OnWithParameter<T : Any> : OnClause {
    override lateinit var message: KClass<out Message>
    lateinit var action: suspend (value: T) -> Unit
    override var filter: ((message: Message) -> Boolean) = { _ -> true }
    lateinit var map: (message: Message) -> T
}

