package ch.fhnw.imvs.reactive2

interface Message {
    val source: String
}

data class StartTimer(override val source: String = "Timer") : Message
data class TimerEnded(override val source: String = "Timer") : Message

data class RunSystem(override val source: String = "System") : Message
