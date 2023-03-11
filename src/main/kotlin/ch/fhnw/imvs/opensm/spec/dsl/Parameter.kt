package ch.fhnw.imvs.opensm.spec.dsl

import kotlinx.serialization.Serializable

@Serializable
data class Parameter(
    val type: String,
    val default: String
)
