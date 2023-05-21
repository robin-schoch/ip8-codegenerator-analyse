package ch.fhnw.imvs.opensm.core.mapper

import ch.fhnw.imvs.opensm.core.PrimitiveResolver
import ch.fhnw.imvs.opensm.core.model.*
import ch.fhnw.imvs.opensm.spec.SMSpec
import ch.fhnw.imvs.opensm.spec.dsl.Parameter
import ch.fhnw.imvs.opensm.spec.dsl.Transition


fun SMSpec.toGenModel(primitiveResolver: PrimitiveResolver): GenModel {

    fun String.getKey(): String = split('/').last()
    fun String.toPrimitive() = primitiveResolver.primitiveOf(PrimitiveTyp.of(this))
    fun Parameter.formatDefaultValue() = primitiveResolver.defaultValueOf(PrimitiveTyp.of(type), default)
    fun List<Map.Entry<String, Parameter>>.toGenParameters() =
        map { GenParameter(it.key.getKey(), it.value.type.toPrimitive(), it.value.formatDefaultValue()) }

    fun String.toGenEvent(machine: String): GenEvent {
        val event = events[getKey()] ?: error("could not resolve events")
        val pKeys = event.parameters.map { param -> param.getKey() }
        val p = parameters.entries.filter { (k, v) -> k.getKey() in pKeys }.toGenParameters()
        return GenEvent(getKey(), machine, p)
    }

    fun String.toGenEffect(machine: String): GenEffect = GenEffect(getKey(), machine)
    fun String.toGenState(machine: String) =
        GenState(
            getKey(),
            machine,
            emptyList(),
            states[getKey()]?.parameters?.map { GenParameter("", "", "") } ?: emptyList())


    fun List<Map.Entry<String, Transition>>.mapToGenTransition(machine: String) =
        map { (k, v) ->
            GenTransition(
                v.event.toGenEvent(machine),
                machine,
                v.target.toGenState(machine),
                v.effect?.toGenEffect(machine)
            )
        }

    fun List<String>.mapStatesToGenStates(machine: String) = map {
        val s = states[it.getKey()] ?: error("could not resolve state")
        val ts = transitions.entries.filter { (k, v) -> v.source.getKey() == it.getKey() }.mapToGenTransition(machine)
        val pKeys = s.parameters.map { param -> param.getKey() }
        val p = parameters.entries.filter { (k, v) -> k.getKey() in pKeys }.toGenParameters()
        GenState(it.getKey(), machine, ts, p)
    }

    fun List<String>.mapToGenEffects(machine: String) = map {
        val s = effects[it.getKey()] ?: error("could not resolve effect")
        GenEffect(it.getKey(), machine)
    }

    fun List<String>.mapEventsToGenEvents(machine: String) = map { it.toGenEvent(machine) }

    val machine = stateMachines
        .map { (key, m) ->
            GenStateMachine(
                key,
                m.initialState.toGenState(key.getKey()),
                m.states.mapStatesToGenStates(key.getKey()),
                m.events.mapEventsToGenEvents(key.getKey()),
                m.effects.mapToGenEffects(key.getKey())
            )
        }

    return GenModel(machine)
}