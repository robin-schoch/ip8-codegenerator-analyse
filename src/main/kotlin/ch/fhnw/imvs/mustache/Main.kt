package ch.fhnw.imvs.mustache

import ch.fhnw.imvs.semdsl.DSLParser
import ch.fhnw.imvs.semdsl.GeneratorRegistry
import ch.fhnw.imvs.semdsl.stage1.CSharpJsonGenerator
import ch.fhnw.imvs.semdsl.stage2.CSharpGenerator
import kotlinx.cli.ArgParser
import kotlinx.cli.ArgType
import kotlinx.cli.default


fun main(args: Array<String>) {
    CSharpGenerator.register()
    CSharpJsonGenerator.register()
    val parser = ArgParser("${App.appName}:: ${App.version}")
    val outputDir by parser.option(ArgType.String, shortName = "O", description = "Path to Output Directory")
        .default(App.outputDir)
    val generator by parser.option(
        ArgType.String,
        shortName = "G",
        description = "Select generator ${GeneratorRegistry.listGenerators()}"
    ).default(CSharpGenerator.key)
    val inputPath by parser.option(
        ArgType.String,
        shortName = "in",
        description = "Input path of file"
    ).default("json/state.json")
    parser.parse(args)

    val jsonParser = DSLParser(inputPath)
    with(GeneratorRegistry.useGenerate(generator)) {
        println("Using $key ")
        initialise(jsonParser.dsl)
        generateStateMachines("$outputDir/$key", listMachines())
    }
    println("Successfully generated State Machines")
}

object App {
    const val appName = "SEM Generator"
    const val version = "0.0.1"
    const val outputDir = "/Users/robin/Documents/GitHub/ip8-codegenerator-analyse/output/generator"
}