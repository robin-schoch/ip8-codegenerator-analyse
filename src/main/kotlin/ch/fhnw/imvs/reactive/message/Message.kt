package ch.fhnw.imvs.reactive.message

interface Message {

}


data class AnimalMessage(val animal: String) : Message {

    fun scream() = "aaaaudf"
}

data class HumanMessage(val speech: List<String>) : Message {
    fun shout() = "nice"
}