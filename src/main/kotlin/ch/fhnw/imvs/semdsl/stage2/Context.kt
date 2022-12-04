package ch.fhnw.imvs.semdsl.stage2

import ch.fhnw.imvs.semdsl.dsl.*

object Context {

    val propertyContext: MutableMap<String, GeneratedProperty> = mutableMapOf()

    val actionContext: MutableMap<String, (List<ParameterWithProperty>) -> String> = mutableMapOf()

    val invocationContext: MutableMap<String, String> = mutableMapOf()

    fun registerProperties(properties: List<Property>) {
        properties.filter { it.source == PropertySource.VARIABLE }.map {
            GeneratedProperty(it.id, it.use(), it.statement())
        }.forEach { propertyContext[it.hash] = it }
    }

    fun registerAction(actions: List<Action>) {
        actions.forEach { actionContext[it.id] = { vars -> it.generate(vars) } }
    }

    fun registerInvocation(invocations: List<Invocation>) {
        
    }
}

data class GeneratedProperty(val hash: String, val use: String, val definition: String)
