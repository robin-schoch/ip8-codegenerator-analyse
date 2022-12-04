package ch.fhnw.imvs.templatestring

import ch.fhnw.imvs.semdsl.DSLParser
import com.github.mustachejava.DefaultMustacheFactory
import com.github.mustachejava.MustacheFactory
import java.io.File


fun main() {
    val parser = DSLParser("json/state.json")
    val mf: MustacheFactory = DefaultMustacheFactory()
    val m = mf.compile("template/v2/jsonStateMachine.mustache")
    val outputDir = "/Users/robin/Documents/GitHub/ip8-codegenerator-analyse/output"
    File(outputDir).mkdirs()

    parser.stateMachines.forEach { data ->
        val output = "$outputDir/${data.machine.name.lowercase()}"
        File(output).mkdir()
        File("$output/${data.machine.name}JsonMachine.cs").bufferedWriter().use { m.execute(it, data) }
    }

    val m2 = mf.compile("template/v2/registry.mustache")
    File("$outputDir/registry.cs").bufferedWriter().use { m2.execute(it, parser.registry) }
}
