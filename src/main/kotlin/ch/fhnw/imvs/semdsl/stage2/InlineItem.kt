package ch.fhnw.imvs.semdsl.stage2

typealias InlineItems = Map<String, InlineItem>

interface InlineableItem {

    fun getKey(): String
    fun buildCall(): InlineItem
}

data class InlineItem(val hash: String, val call: (items: InlineItems, parameter: List<String>) -> String)
