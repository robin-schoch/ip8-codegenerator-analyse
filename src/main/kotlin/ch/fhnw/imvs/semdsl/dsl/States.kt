package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.*
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

    context(Context)
    fun inlineInvocations() =
        invocations.fold("") { acc, it ->
            """
            ${inlineElements[it]}""" + acc
        }

    override fun getKey(): String {
        return id
    }

    override fun buildCall(): InlineItem {

        return InlineItem(id) { items, _ ->
            // val definition = "private string ${cleanName}State()"
            // val returnDefinition = "return $cleanName"
            val invocationDefinition = invocations.map { items[it] ?: error("invocation does not exist $it") }
                .map { it.call(items, listOf()) }
                .fold("") { acc, it ->
                    """
                    $it""" + acc
                }

            // listOf(definition) +
            invocationDefinition
            // + listOf(returnDefinition)
        }
    }

    override fun buildStateMachineEntry(): StateMachineItem {

        return StateMachineItem(id) { _, _ -> listOf(cleanName) }
    }
}