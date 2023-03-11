package ch.fhnw.imvs.opensm.core

import ch.fhnw.imvs.opensm.core.lambda.CamelCase
import ch.fhnw.imvs.opensm.core.lambda.Capitalize
import ch.fhnw.imvs.opensm.core.lambda.UpperCase

object ParentContext {

    private val ctx: MutableMap<String, Any> = mutableMapOf(
        "uppercase" to UpperCase(),
        "capitalize" to Capitalize(),
        "camelcase" to CamelCase()
    )

    val context
        get() = ctx.toMap()

    fun add(key: String, value: Any) {
        ctx[key] = value
    }

    fun add(elements: Map<String, Any>) {
        ctx.putAll(elements)
    }
}
