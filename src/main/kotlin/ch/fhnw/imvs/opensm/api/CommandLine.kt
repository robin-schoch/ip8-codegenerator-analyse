package ch.fhnw.imvs.opensm.api

import ch.fhnw.imvs.opensm.core.CodeGenConfig
import ch.fhnw.imvs.opensm.core.FileDeserializer
import ch.fhnw.imvs.opensm.core.WorkFlowConfig
import ch.fhnw.imvs.opensm.generator.JavaSpringGenerator
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
        val packagePath by parser.option(
            ArgType.String,
            shortName = "pkg",
            description = "Package path"
        ).default("ch.fhnw.imvs.statemachine")
        val projectName by parser.option(
            ArgType.String,
            shortName = "pn",
            description = "Project name"
        ).default("open-statemachine")
        val generatorName by parser.option(
            ArgType.String,
            shortName = "g",
            description = "Generator name"
        ).default("tinder-kotlin")
        parser.parse(args)
        val workFlowConfig = WorkFlowConfig(inputPath, packagePath, projectName)
        FileDeserializer.readSpec(workFlowConfig)
        val codeGenConfig = CodeGenConfig()
        with(FileDeserializer) {
            val generator = when (generatorName) {
                "kotlin-tinder" -> KotlinTinderGenerator(workFlowConfig, codeGenConfig, this)
                "java-spring" -> JavaSpringGenerator(workFlowConfig, codeGenConfig, this)
                else -> error("invalid generator")
            }
            generator.generate()
        }
    }
}

fun main(args: Array<String>) = CommandLine.runGeneration(args)