package ch.fhnw.imvs.semdsl

object GeneratorRegistry {

    private val _generators: MutableMap<String, Generator> = mutableMapOf()

    fun register(generator: Generator) {
        _generators[generator.key] = generator
    }

    fun listGenerators() = _generators.values.joinToString(separator = ", ", prefix = "(", postfix = ")") { it.key }

    fun useGenerate(key: String) = _generators[key] ?: error("Generator does not exist")
}