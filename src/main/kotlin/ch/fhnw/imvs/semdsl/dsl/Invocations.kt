package ch.fhnw.imvs.semdsl.dsl

import kotlinx.serialization.Serializable

typealias InvocationId = String


@Serializable
data class Invocation(
    val id: InvocationId,
    val parameters: List<ParameterWithProperty>,
    val action: ActionId,
    val name: String
)