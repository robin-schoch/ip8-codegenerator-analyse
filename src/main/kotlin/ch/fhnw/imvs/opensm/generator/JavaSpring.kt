package ch.fhnw.imvs.opensm.generator

import ch.fhnw.imvs.opensm.core.*
import ch.fhnw.imvs.opensm.core.lambda.toCamelCase
import ch.fhnw.imvs.opensm.core.model.PrimitiveTyp
import ch.fhnw.imvs.opensm.spec.V0_0_10
import ch.fhnw.imvs.opensm.spec.V0_0_8

object JavaPrimitiveResolver : PrimitiveResolver {
    override fun primitiveOf(value: PrimitiveTyp) = when (value) {
        PrimitiveTyp.BOOLEAN -> "Boolean"
        PrimitiveTyp.INTEGER -> "Integer"
        PrimitiveTyp.STRING -> "String"
    }

    override fun defaultValueOf(value: PrimitiveTyp, default: String): String {
        return when (value) {
            PrimitiveTyp.BOOLEAN -> if (default.lowercase() == "true") "true" else "false"
            PrimitiveTyp.INTEGER -> default
            PrimitiveTyp.STRING -> "\"$default\""
        }
    }
}

data class JavaSpringGenerator(
    override val workFlowConfig: WorkFlowConfig,
    override val codeGenConfig: CodeGenConfig,
    override val deserializer: Deserializer
) : BaseGenerator, Deserializer by deserializer {

    override val name = "JavaSpringGenerator"
    override val supportedVersion = V0_0_8 to V0_0_10
    override val primitiveResolver = JavaPrimitiveResolver

    override fun process(): Sequence<Output> = sequence {
        val templates = loadTemplates()
        val stateTemplate =
            templates.find { it.nameWithoutExtension == "states" } ?: throw RuntimeException("state template not found")
        val eventTemplate =
            templates.find { it.nameWithoutExtension == "events" } ?: throw RuntimeException("event template not found")
        val configurationTemplate =
            templates.find { it.nameWithoutExtension == "configuration" }
                ?: throw RuntimeException("configuration template not found")
        val runnerTemplate =
            templates.find { it.nameWithoutExtension == "application-runner" }
                ?: throw RuntimeException("application-runner template not found")
        val packagePath = "/src/main/java/" + ParentContext.get("package").toString().replacePackageDeclarationToPath()

        yield("${packagePath}/ApplicationRunner.java" withContent (runnerTemplate compileTemplate genModel))
        genModel.stateMachines.forEach {
            yieldAll(
                listOf(
                    "${packagePath}/${it.machineState.toCamelCase()}.java" withContent (stateTemplate compileTemplate it),

                    "${packagePath}/${it.machineEvent.toCamelCase()}.java" withContent (eventTemplate compileTemplate it),

                    "${packagePath}/${it.name.toCamelCase()}Configuration.java" withContent (configurationTemplate compileTemplate it)
                )
            )
        }
    }

    override fun preProcessing() {
        ParentContext.add("package", workFlowConfig.packagePath)
        ParentContext.add("projectName", workFlowConfig.projectName)
    }

    override fun postProcessing() {
        println("done post processing")
    }

    private fun String.replacePackageDeclarationToPath() = replace(".", "/")
}