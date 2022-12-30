package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.InlineItem
import ch.fhnw.imvs.semdsl.stage2.InlineableItem
import kotlinx.serialization.Serializable

typealias ConjunctionId = String

@Serializable
data class Conjunction(
    val id: ConditionId,
    val name: String,
    val terms: List<String>
) : InlineableItem {
    override fun getKey(): String {
        return id
    }

    override fun buildCall(): InlineItem {
        return InlineItem(id) { items, actionParams ->
            terms.map { items[it] ?: error("Parameter with id $it does not exist") }
                .joinToString(separator = " && ", prefix = "(", postfix = ")") { it.call(items, actionParams) }
        }
    }
}
