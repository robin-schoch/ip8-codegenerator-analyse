package ch.fhnw.imvs.semdsl.dsl

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
}