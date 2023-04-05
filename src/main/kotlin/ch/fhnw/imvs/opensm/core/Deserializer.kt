package ch.fhnw.imvs.opensm.core

import ch.fhnw.imvs.opensm.spec.SMSpec
import ch.fhnw.imvs.semdsl.modules
import kotlinx.serialization.ExperimentalSerializationApi
import kotlinx.serialization.json.Json
import kotlinx.serialization.json.decodeFromStream
import java.io.File

interface Deserializer {

    fun readSpec(workFlowConfig: WorkFlowConfig): SMSpec

    fun Sequence<Output>.write(workFlowConfig: WorkFlowConfig)
}

@OptIn(ExperimentalSerializationApi::class)
object FileDeserializer : Deserializer {

    private val json = Json {
        ignoreUnknownKeys = true
        serializersModule = modules
    }

    override fun readSpec(workFlowConfig: WorkFlowConfig): SMSpec {
        with(File(workFlowConfig.specPath).inputStream()) {
            return json.decodeFromStream(this ?: error("Specification file not found abort generation"))
        }
    }

    override fun Sequence<Output>.write(workFlowConfig: WorkFlowConfig) {
        forEachIndexed() { _, output ->
            File("${workFlowConfig.projectName}${output.first}").let {
                it.parentFile.mkdirs()
                it.writeText(output.second)
                println(it.absolutePath)
            }
        }
    }
}