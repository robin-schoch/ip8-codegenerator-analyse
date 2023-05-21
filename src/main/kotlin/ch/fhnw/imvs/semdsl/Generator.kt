package ch.fhnw.imvs.semdsl

import ch.fhnw.imvs.semdsl.dsl.JSONDSL

interface Generator {

    val key: String

    fun register() = GeneratorRegistry.register(this)

    fun initialise(dsl: JSONDSL)

    fun generateStateMachines(outputDir: String, machines: Set<String>)

    fun listMachines(): Set<String>
}