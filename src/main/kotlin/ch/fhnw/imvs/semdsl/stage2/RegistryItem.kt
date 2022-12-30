package ch.fhnw.imvs.semdsl.stage2

typealias RegistryItems = Map<String, RegistryItem>

interface RegistrableItem {

    fun getKey(): String
    fun buildEntry(): RegistryItem
}

data class RegistryItem(val hash: String, val entry: (InlineItems) -> String) {

}
