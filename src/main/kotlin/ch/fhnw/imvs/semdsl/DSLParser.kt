@file:OptIn(ExperimentalSerializationApi::class)

package ch.fhnw.imvs.semdsl


import ch.fhnw.imvs.semdsl.dsl.*
import kotlinx.serialization.ExperimentalSerializationApi
import kotlinx.serialization.json.Json
import kotlinx.serialization.json.decodeFromStream
import kotlinx.serialization.modules.plus

@ExperimentalSerializationApi
val modules = listOf(
    actionSerializersModule
).reduceRight { serializersModule, modules -> serializersModule + modules }


class DSLParser(path: String) {

    @OptIn(ExperimentalSerializationApi::class)
    private val json = Json {
        ignoreUnknownKeys = true
        serializersModule = modules
    }

    @OptIn(ExperimentalSerializationApi::class)
    val dsl: JSONDSL by lazy {
        with(javaClass.classLoader.getResourceAsStream(path)) { json.decodeFromStream(this!!) }
    }


}



