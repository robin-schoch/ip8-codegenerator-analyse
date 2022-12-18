package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.Context
import kotlinx.serialization.Serializable

typealias DisjunctionId = String

@Serializable
data class Disjunction(
    override val id: DisjunctionId,
    val name: String,
    val terms: List<String>
) : ParseableTerm {
    override fun allDependencyParsed(parsedElements: Set<String>) = parsedElements.containsAll(terms)

    context(Context)
    override fun use(): String = terms
        .map { inlineElements[it]!! }
        .joinToString(separator = " || ", prefix = "(", postfix = ")") { it }
}
