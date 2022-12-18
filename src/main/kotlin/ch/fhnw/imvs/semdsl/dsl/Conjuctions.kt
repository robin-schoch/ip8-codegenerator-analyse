package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.Context
import kotlinx.serialization.Serializable

typealias ConjunctionId = String

@Serializable
data class Conjunction(
    override val id: ConditionId,
    val name: String,
    val terms: List<String>
) : ParseableTerm {
    context(Context)
    override fun use(): String = terms
        .map { inlineElements[it]!! }
        .joinToString(separator = " && ", prefix = "(", postfix = ")") { it }

    override fun allDependencyParsed(parsedElements: Set<String>) = parsedElements.containsAll(terms)

}
