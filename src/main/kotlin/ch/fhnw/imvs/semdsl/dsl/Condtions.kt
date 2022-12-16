package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.Context
import kotlinx.serialization.*
import kotlinx.serialization.encoding.Decoder
import kotlinx.serialization.json.JsonClassDiscriminator
import kotlinx.serialization.json.JsonDecoder

typealias ConditionId = String

@OptIn(ExperimentalSerializationApi::class)
@Serializable
@JsonClassDiscriminator("operator")
sealed class Condition() {
    abstract val id: ConditionId
    abstract val left: PropertyId
    abstract val operator: String
    abstract val right: PropertyId
    abstract val name: String

    context(Context) abstract fun use(): String
}

fun <T> KSerializer<T>.fallback(value: T) = object : KSerializer<T> by this {
    override fun deserialize(decoder: Decoder): T {
        check(decoder is JsonDecoder) { "This deserializer only supports deserializing JSON" }
        return try {
            decoder.json.decodeFromJsonElement(this@fallback, decoder.decodeJsonElement())
        } catch (throwable: Throwable) {
            value
        }
    }
}

@Serializable
@SerialName("==")
class EqualCondition(
    override val id: ConditionId,
    override val left: PropertyId,
    override val operator: String,
    override val right: PropertyId,
    override val name: String
) : Condition() {
    context(Context) override fun use() = "${propertyContext[left]!!.use}  == ${propertyContext[right]!!.use}"
}

@Serializable
@SerialName(">=")
class GreatThenOrEqualCondition(
    override val id: ConditionId,
    override val left: PropertyId,
    override val operator: String,
    override val right: PropertyId,
    override val name: String
) : Condition() {
    context(Context) override fun use() = "${propertyContext[left]!!.use} >= ${propertyContext[right]!!.use}"
}

@Serializable
@SerialName(">")
class GreatThenCondition(
    override val id: ConditionId,
    override val left: PropertyId,
    override val operator: String,
    override val right: PropertyId,
    override val name: String
) : Condition() {
    context(Context) override fun use() = "${propertyContext[left]!!.use}  > ${propertyContext[right]!!.use}"
}

@Serializable
@SerialName("<")
class LessThenCondition(
    override val id: ConditionId,
    override val left: PropertyId,
    override val operator: String,
    override val right: PropertyId,
    override val name: String
) : Condition() {
    context(Context) override fun use() = "${propertyContext[left]!!.use}  < ${propertyContext[right]!!.use}"
}

@Serializable
@SerialName("<=")
class LessOrEqualThenCondition(
    override val id: ConditionId,
    override val left: PropertyId,
    override val operator: String,
    override val right: PropertyId,
    override val name: String
) : Condition() {
    context(Context) override fun use() = "${propertyContext[left]!!.use}  <= ${propertyContext[right]!!.use}"
}