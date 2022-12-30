package ch.fhnw.imvs.semdsl.stage2


typealias TransitionItems = Map<String, List<TransitionItem>>

interface TransitionableItem {

    fun getKey(): String

    fun buildTransition(): TransitionItem
}

data class TransitionItem(val hash: String, val transition: String) {
}