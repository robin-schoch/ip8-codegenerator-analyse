package ch.fhnw.imvs.semdsl.stage2

import java.util.*

object Context {

    val propertyContext: Map<String, Any> = mapOf()

    fun registerProperties(properties: List<Properties>) {
        properties.map { }

    }
}

data class ParseDependencies<T>(val dependentOn: MutableSet<String>, val element: T)