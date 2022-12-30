package ch.fhnw.imvs.semdsl

import ch.fhnw.imvs.semdsl.dsl.JSONDSL

interface Generator {

    fun initialise(dsl: JSONDSL)


    fun generateRegistry(mustacheTemplatePath: String, outputDir: String)

    fun generateStateMachines(mustacheTemplatePath: String, outputDir: String, machines: Set<String>)

    fun listMachines(): Set<String>
}