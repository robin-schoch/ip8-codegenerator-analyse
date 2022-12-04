package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.Context
import kotlinx.serialization.ExperimentalSerializationApi
import kotlinx.serialization.SerialName
import kotlinx.serialization.Serializable
import kotlinx.serialization.json.JsonClassDiscriminator

typealias ActionId = String

@OptIn(ExperimentalSerializationApi::class)
@Serializable
@JsonClassDiscriminator("id")
sealed class Action {
    abstract val id: ActionId
    abstract val name: String
    abstract val description: String
    abstract val hardcoded: Boolean
    abstract val parameters: List<ParameterId>
    abstract val constraints: List<List<String>>

    context(Context)
    open fun generate(vars: List<ParameterWithProperty>): String = ""
}

@Serializable
@SerialName("5ac89853-9983-455f-9cf5-afd9eaef51c0")
class ReduceMaximumTemperatureReservoirTemperatureRangeService(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    context(Context) override fun generate(vars: List<ParameterWithProperty>): String = TODO()
}

@Serializable
@SerialName("f76b75ae-dbee-4c45-aba0-b287b9edcf5b")
class StopAndResetTimerActionHandler(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    context(Context) override fun generate(vars: List<ParameterWithProperty>): String =
        "${propertyContext[vars[0].property]!!.use}.StopAndReset()"
}


@Serializable
@SerialName("82fe2d8c-4750-4057-a988-c187738aa678")
class StartTimerActionHandler(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    context(Context) override fun generate(vars: List<ParameterWithProperty>): String =
        "${propertyContext[vars[0].property]!!.use}.Start()"
}


@Serializable
@SerialName("37b56414-17ef-4486-af60-6758b4449487")
class CloseReservoirBypassValve(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    context(Context) override fun generate(vars: List<ParameterWithProperty>): String =
        TODO("i dont know ho this should look like")
}


@Serializable
@SerialName("f3708d7f-b014-4c47-8871-76b83232e611")
class OpenReservoirBypassValve(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    context(Context) override fun generate(vars: List<ParameterWithProperty>): String =
        TODO("i dont know ho this should look like")
}

@Serializable
@SerialName("5811a09a-9ea4-4bfb-9419-e57c7c9804eb")
class CloseInletAirBypassValve(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    context(Context) override fun generate(vars: List<ParameterWithProperty>): String =
        TODO("i dont know ho this should look like")
}

@Serializable
@SerialName("e3ac8e13-81e6-4c40-b6e8-f43eeb90678c")
class OpenInletAirBypassValve(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    context(Context) override fun generate(vars: List<ParameterWithProperty>): String =
        TODO("i dont know ho this should look like")
}


@Serializable
@SerialName("6f12dda9-5b01-4139-8fc6-f88114f78bbe")
class EnsureOffCompressor(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    context(Context) override fun generate(vars: List<ParameterWithProperty>): String =
        TODO("i dont know ho this should look like")
}

@Serializable
@SerialName("59c91b75-6faa-4caf-aab5-dc2222df39da")
class EnsureOnCompressor(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    context(Context) override fun generate(vars: List<ParameterWithProperty>): String =
        TODO("i dont know ho this should look like")
}

@Serializable
@SerialName("6271ba44-0068-407b-ad14-b665a83136e0")
class InvokeIf(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    context(Context) override fun generate(vars: List<ParameterWithProperty>): String =
        // todo first vars call is for condition, condition have no been parsed yet
        """
            if(${propertyContext[vars[0].property]!!.use}) {
                ${propertyContext[vars[1].property]!!.use}
            }
        """.trimIndent()
}

@Serializable
@SerialName("d1551641-1941-457d-98f2-37baa327d23a")
class Subtract(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    context(Context) override fun generate(vars: List<ParameterWithProperty>): String =
        "${propertyContext[vars[0].property]!!.use} -= ${propertyContext[vars[1].property]!!.use}"
}

@Serializable
@SerialName("caf92d53-79fd-414b-84cf-9d9d9475ff76")
class Add(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    context(Context) override fun generate(vars: List<ParameterWithProperty>): String =
        "${propertyContext[vars[0].property]!!.use} += ${propertyContext[vars[1].property]!!.use}"
}

@Serializable
@SerialName("ec7e4575-01ef-4e23-a46c-805615255b61")
class Decrement(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    context(Context) override fun generate(vars: List<ParameterWithProperty>): String =
        "${propertyContext[vars[0].property]!!.use} --"
}

@Serializable
@SerialName("41a3a297-d0bc-4d2f-99de-d202509602b0")
class Increment(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    context(Context) override fun generate(vars: List<ParameterWithProperty>): String =
        "${propertyContext[vars[0].property]!!.use} ++"
}

@Serializable
@SerialName("51514694-20e7-42f3-a7f0-63f73c38e3a9")
class Zero(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    context(Context) override fun generate(vars: List<ParameterWithProperty>): String =
        "${propertyContext[vars[0].property]!!.use} = 0"
}

@Serializable
@SerialName("cb77de99-4505-4c18-b05c-77e2c02beb24")
class Assign(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    context(Context) override fun generate(vars: List<ParameterWithProperty>): String =
        "${propertyContext[vars[0].property]!!.use} = ${propertyContext[vars[1].property]!!.use}"
}