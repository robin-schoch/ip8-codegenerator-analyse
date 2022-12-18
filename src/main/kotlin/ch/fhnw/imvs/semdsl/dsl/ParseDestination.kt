package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.Context

sealed interface RegistryDestination {

    fun registryDeclaration(): String
}

sealed interface ParseableTerm {

    val id: String
    fun allDependencyParsed(parsedElements: Set<String>): Boolean

    context(Context)
    fun use(): String
}

