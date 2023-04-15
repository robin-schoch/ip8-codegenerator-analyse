package ch.fhnw.imvs.opensm.core

import ch.fhnw.imvs.opensm.core.mapper.toGenModel
import ch.fhnw.imvs.opensm.core.model.GenModel
import ch.fhnw.imvs.opensm.spec.SMSpec
import ch.fhnw.imvs.opensm.spec.SupportedSpecRange
import ch.fhnw.imvs.opensm.spec.isSupportedSpecVersion
import com.samskivert.mustache.Mustache
import java.io.File
import java.io.FileReader
import java.io.StringWriter
import kotlin.system.exitProcess

data class Output(val filename: String, val fileContent: String)

infix fun String.withContent(content: String) = Output(this, content)

interface BaseGenerator : Deserializer {

    val name: String

    val supportedVersion: SupportedSpecRange

    val deserializer: Deserializer

    val primitiveResolver: PrimitiveResolver

    val templateDirectoryPath: String
        get() = "generators/$name"
    val partialTemplateDir: String
        get() = "generators/util"

    val mustacheCompiler: Mustache.Compiler
        get() = Mustache.compiler()
            .withLoader { name ->
                with(javaClass.classLoader.getResource("$partialTemplateDir/$name.mustache")) {
                    FileReader(this?.file ?: error("partial template directory is missing generation aborted"))
                }
            }
    val smSpec: SMSpec
        get() = deserializer.readSpec(workFlowConfig)

    val genModel: GenModel
        get() = smSpec.toGenModel(this.primitiveResolver)

    val workFlowConfig: WorkFlowConfig

    val codeGenConfig: CodeGenConfig

    val languageSpecificPrimitives: Map<String, String>

    fun loadTemplates(): Sequence<File> {
        return with(javaClass.classLoader.getResource(templateDirectoryPath)) {
            val dir = this?.file?.let { File(it) } ?: error("template directory is missing generation aborted")
            dir.walk().asSequence().drop(1)
        }
    }

    fun compileTemplate(template: File, context: Any): String {
        return with(mustacheCompiler.compile(File(template.absolutePath).bufferedReader())) {
            StringWriter().use { w ->
                execute(context, ParentContext.context, w)
                w.flush()
                w.toString()
            }
        }
    }

    fun generate() {
        validate()
        preProcessing()
        process().write(workFlowConfig)
        postProcessing()
    }

    fun validate() {
        isCompatibleVersion()
    }

    fun isCompatibleVersion() {
        if (!supportedVersion.isSupportedSpecVersion(smSpec.version)) {
            println("unsupported spec version use different generator or spec")
            exitProcess(0);
        }
    }

    fun preProcessing()

    fun process(): Sequence<Output>

    fun postProcessing()
}