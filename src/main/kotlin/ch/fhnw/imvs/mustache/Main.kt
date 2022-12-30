package ch.fhnw.imvs.mustache

import ch.fhnw.imvs.semdsl.DSLParser
import ch.fhnw.imvs.semdsl.stage1.CSharpJsonGenerator
import ch.fhnw.imvs.semdsl.stage2.CSharpGenerator


object Stage1 {
    @JvmStatic
    fun main(args: Array<String>) {
        val parser = DSLParser("json/state.json")
        val outputDir = "/Users/robin/Documents/GitHub/ip8-codegenerator-analyse/output/stage1"
        CSharpJsonGenerator.initialise(parser.dsl)
        CSharpJsonGenerator.generateStateMachines(
            "template/v2/jsonStateMachine.mustache",
            outputDir,
            CSharpJsonGenerator.listMachines()
        )
    }
}

object Stage2Refactored {

    @JvmStatic
    fun main(args: Array<String>) {
        val parser = DSLParser("json/state.json")
        CSharpGenerator.initialise(parser.dsl)
        val outputDir = "/Users/robin/Documents/GitHub/ip8-codegenerator-analyse/output/stage2refactored"
        CSharpGenerator.generateRegistry("template/v2/refactored/registry.mustache", outputDir)
        CSharpGenerator.generateStateMachines(
            "template/v2/refactored/resolveJsonStateMachine.mustache",
            outputDir,
            CSharpGenerator.listMachines()
        )
    }
}