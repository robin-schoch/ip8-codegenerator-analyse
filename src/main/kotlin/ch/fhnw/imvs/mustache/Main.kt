package ch.fhnw.imvs.mustache

import ch.fhnw.imvs.semdsl.DSLParser
import ch.fhnw.imvs.semdsl.stage2.Context
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

object Stage2 {
    @JvmStatic
    fun main(args: Array<String>) {
        val parser = DSLParser("json/state.json")
        val mf: MustacheFactory = DefaultMustacheFactory()
        val m2 = mf.compile("template/v2/registry.mustache")
        val outputDir = "/Users/robin/Documents/GitHub/ip8-codegenerator-analyse/output/stage2"
        File(outputDir).mkdirs()
        Context.registerProperties(parser.properties)
        // Context.inlineElements.forEach { (t, u) -> println(u) }
        Context.registryElements.forEach { (t, u) -> println(u) }
        Context.registerTerm(parser.terms)
        File("$outputDir/registry.cs").bufferedWriter().use { m2.execute(it, Context.properties()) }

        Context.registerAction(parser.actions)

        Context.registerInvocation(parser.invocations)
        Context.registerEvents(parser.events)
        //  Context.eventContext.forEach { (_, u) -> println(u) }
        Context.registerTransitions(parser.transitions)

    }
}