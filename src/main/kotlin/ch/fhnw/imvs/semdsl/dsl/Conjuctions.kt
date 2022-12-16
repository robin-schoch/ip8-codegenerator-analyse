package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.Context
import kotlinx.serialization.Serializable

typealias ConjunctionId = String

@Serializable
data class Conjunction(
    val id: ConditionId,
    val name: String,
    val terms: List<String>
) {
    context(Context) fun use(): String = terms
        .map { termContext[it]!! }
        .joinToString(separator = " && ", prefix = "(", postfix = ")") { it }
}
