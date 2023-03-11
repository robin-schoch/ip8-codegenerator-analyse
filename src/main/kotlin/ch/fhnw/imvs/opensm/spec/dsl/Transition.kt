package ch.fhnw.imvs.opensm.spec.dsl

import kotlinx.serialization.Serializable

@Serializable
data class Transition(
    val event: String,
    val source: String,
    val target: String,
    val effect: String? = null
)
