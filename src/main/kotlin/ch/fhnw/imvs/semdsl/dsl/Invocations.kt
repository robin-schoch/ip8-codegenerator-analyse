package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.InlineItem
import ch.fhnw.imvs.semdsl.stage2.InlineItems
import ch.fhnw.imvs.semdsl.stage2.InlineableItem
import kotlinx.serialization.Serializable

typealias InvocationId = String


@Serializable
data class Invocation(
    val id: InvocationId,
    val parameters: List<ParameterWithProperty>,
    val action: ActionId,
    val name: String
) : InlineableItem {

    fun allDependencyParsed(parsedElements: Set<String>) = parsedElements.containsAll(parameters.map { it.property })
    override fun getKey(): String {
        return id
    }

    override fun buildCall(): InlineItem {
        return InlineItem(id) { items: InlineItems, actionParams ->
            val action = items[action] ?: error("Action does not exist")
            action.call(items, parameters.map { it.property })
        }
    }

}