package ch.fhnw.imvs.opensm.generator

import ch.fhnw.imvs.opensm.core.*
import ch.fhnw.imvs.opensm.core.lambda.CamelCaseTransformer
import ch.fhnw.imvs.opensm.core.model.PrimitiveTyp
import ch.fhnw.imvs.opensm.spec.V0_0_10
import ch.fhnw.imvs.opensm.spec.V0_0_8

object KotlinPrimitiveResolver : PrimitiveResolver {
    override fun primitiveOf(value: PrimitiveTyp) = when (value) {
        PrimitiveTyp.BOOLEAN -> "Boolean"
        PrimitiveTyp.INTEGER -> "Int"
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

data class KotlinTinderGenerator(
    override val workFlowConfig: WorkFlowConfig,
    override val codeGenConfig: CodeGenConfig,
    override val deserializer: Deserializer
) : BaseGenerator, Deserializer by deserializer {

    override val name = "KotlinTinderGenerator"
    override val supportedVersion = V0_0_8 to V0_0_10
    override val primitiveResolver = KotlinPrimitiveResolver

    override val languageSpecificPrimitives: Map<String, String>
        get() = mutableMapOf()

    override fun process(): Sequence<Output> {
        val packagePath =
            "/src/main/kotlin/" + ParentContext.get("package").toString().replacePackageDeclarationToPath()

        val declarationTemplate =
            loadTemplates().find { it.nameWithoutExtension == "state" } ?: error("abort generation template is missing")

        return sequence<Output> {
            val output = genModel.stateMachines.map {
                "${packagePath}/${CamelCaseTransformer.transform(it.name)}.kt" to compileTemplate(
                    declarationTemplate,
                    it
                )
            }
            yieldAll(output)
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