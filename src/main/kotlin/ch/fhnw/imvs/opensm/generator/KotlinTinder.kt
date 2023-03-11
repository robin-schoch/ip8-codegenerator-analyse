package ch.fhnw.imvs.opensm.generator

import ch.fhnw.imvs.opensm.core.*
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
    override val primitiveResolver: PrimitiveResolver
        get() = KotlinPrimitiveResolver

    override val languageSpecificPrimitives: Map<String, String>
        get() = mutableMapOf()

    override fun process(): Sequence<Output> = loadTemplates().map { template ->
        "${template.nameWithoutExtension}.kt" to compileTemplate(template, genModel)
    }

    override fun postProcessing() {
        println("done post processing")
    }
}
