package ch.fhnw.imvs.opensm.api

import ch.fhnw.imvs.opensm.core.CodeGenConfig
import ch.fhnw.imvs.opensm.core.FileDeserializer
import ch.fhnw.imvs.opensm.core.WorkFlowConfig
import ch.fhnw.imvs.opensm.generator.KotlinTinderGenerator
import kotlinx.cli.ArgParser
import kotlinx.cli.ArgType
import kotlinx.cli.default

object CommandLine {
    const val appName = "OpenSM generator"
    const val version = "0.0.1"

    fun runGeneration(args: Array<String>) {
        val parser = ArgParser("${appName}:: $version")

        val inputPath by parser.option(
            ArgType.String,
            shortName = "in",
            description = "Input file"
        ).default("opensm.json")
        parser.parse(args)
        println("hallo")
        val workFlowConfig = WorkFlowConfig(inputPath)
        FileDeserializer.readSpec(workFlowConfig)
        val codeGenConfig = CodeGenConfig()
        with(FileDeserializer) {
            val generator = KotlinTinderGenerator(workFlowConfig, codeGenConfig, this)
            generator.generate()
        }
    }
}

fun main(args: Array<String>) = CommandLine.runGeneration(args)

