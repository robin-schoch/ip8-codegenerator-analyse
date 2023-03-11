package ch.fhnw.imvs.opensm.spec.dsl

import kotlinx.serialization.Serializable

@Serializable
data class State(
    val description: String,
    val parameters: List<String> = emptyList()
)
