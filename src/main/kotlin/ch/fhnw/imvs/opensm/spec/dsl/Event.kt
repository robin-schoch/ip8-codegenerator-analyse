package ch.fhnw.imvs.opensm.spec.dsl

import kotlinx.serialization.Serializable

@Serializable
data class Event(
    val parameters: List<String> = listOf()
)
