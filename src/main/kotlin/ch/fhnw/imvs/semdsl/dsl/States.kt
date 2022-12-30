package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.InlineItem
import ch.fhnw.imvs.semdsl.stage2.InlineableItem
import ch.fhnw.imvs.semdsl.stage2.StateMachinableItem
import ch.fhnw.imvs.semdsl.stage2.StateMachineItem
import kotlinx.serialization.Serializable

typealias StateId = String

@Serializable
data class State(
    val id: StateId,
    val name: String,
    val description: String,
    val invocations: List<InvocationId>
) : InlineableItem, StateMachinableItem {
    val cleanName = name.replace(Regex("[^a-zA-Z\\d_]"), "_")
    override fun getKey(): String {
        return id
    }

    override fun buildCall(): InlineItem {
        return InlineItem(id) { items, _ ->
            val invocationDefinition = invocations.map { items[it] ?: error("invocation does not exist $it") }
                .map { it.call(items, listOf()) }
                .fold("") { acc, it ->
                    """
                    $it""" + acc
                }
            invocationDefinition
        }
    }

    override fun buildStateMachineEntry(): StateMachineItem {
        return StateMachineItem(id) { _, _ -> listOf(cleanName) }
    }
}