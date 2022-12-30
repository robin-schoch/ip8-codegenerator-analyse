package ch.fhnw.imvs.mustache

import ch.fhnw.imvs.semdsl.DSLParser
import ch.fhnw.imvs.semdsl.stage2.CSharpGenerator
import com.github.mustachejava.DefaultMustacheFactory
import com.github.mustachejava.MustacheFactory
import java.io.File


object Stage1 {
    @JvmStatic
    fun main(args: Array<String>) {
        val parser = DSLParser("json/state.json")
        val mf: MustacheFactory = DefaultMustacheFactory()
        val m = mf.compile("template/v2/jsonStateMachine.mustache")
        val outputDir = "/Users/robin/Documents/GitHub/ip8-codegenerator-analyse/output/stage1"
        File(outputDir).mkdirs()

        parser.stateMachines.forEach { data ->
            val output = "$outputDir/${data.machine.name.lowercase()}"
            File(output).mkdir()
            File("$output/${data.machine.name}JsonMachine.cs").bufferedWriter().use { m.execute(it, data) }
        }
    }
}

object Stage2Refactored {

    @JvmStatic
    fun main(args: Array<String>) {
        val parser = DSLParser("json/state.json")
        CSharpGenerator.initialise(parser.dsl)
        val outputDir = "/Users/robin/Documents/GitHub/ip8-codegenerator-analyse/output/stage2refactored"
        CSharpGenerator.generateRegistry("template/v2/refactored/registry.mustache", outputDir)
        CSharpGenerator.generateStateMachines("template/v2/refactored/resolveJsonStateMachine.mustache", outputDir)
    }
}