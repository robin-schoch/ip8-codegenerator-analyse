package ch.fhnw.imvs.semdsl.stage2

typealias StateMachineItems = Map<String, StateMachineItem>

interface StateMachinableItem {
    fun getKey(): String

    fun buildStateMachineEntry(): StateMachineItem

}

data class StateMachineItem(
    val hash: String,
    val definition: (items: InlineItems, stateMachineItems: StateMachineItems) -> List<String>
)
