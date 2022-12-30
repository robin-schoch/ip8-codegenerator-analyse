package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.Context
import ch.fhnw.imvs.semdsl.stage2.InlineItem
import ch.fhnw.imvs.semdsl.stage2.InlineableItem
import kotlinx.serialization.Serializable

typealias DisjunctionId = String

@Serializable
data class Disjunction(
    override val id: DisjunctionId,
    val name: String,
    val terms: List<String>
) : ParseableTerm, InlineableItem {
    override fun allDependencyParsed(parsedElements: Set<String>) = parsedElements.containsAll(terms)

    context(Context)
    override fun use(): String = terms
        .map { inlineElements[it]!! }
        .joinToString(separator = " || ", prefix = "(", postfix = ")") { it }

    override fun getKey(): String {
        return id
    }

    override fun buildCall(): InlineItem {
        return InlineItem(id) { items, actionParams ->
            terms.map { items[it] ?: error("Parameter with id $it does not exist") }
                .joinToString(separator = " || ", prefix = "(", postfix = ")") { it.call(items, actionParams) }
        }
    }
}
