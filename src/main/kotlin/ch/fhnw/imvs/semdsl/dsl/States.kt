package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.Context
import kotlinx.serialization.Serializable

typealias StateId = String

@Serializable
data class State(
    val id: StateId,
    val name: String,
    val description: String,
    val invocations: List<InvocationId>
) {
    val cleanName = name.replace(Regex("[^a-zA-Z\\d_]"), "_")

    context(Context)
    fun inlineInvocations() =
        invocations.fold("") { acc, it ->
            """
            ${inlineElements[it]}""" + acc
        }
}