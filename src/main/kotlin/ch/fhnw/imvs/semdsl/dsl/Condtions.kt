package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.Context
import kotlinx.serialization.*
import kotlinx.serialization.json.JsonClassDiscriminator

typealias ConditionId = String


@OptIn(ExperimentalSerializationApi::class)
@Serializable
@JsonClassDiscriminator("operator")
sealed class Condition() : ParseableTerm {
    abstract override val id: ConditionId
    abstract val left: PropertyId
    abstract val operator: String
    abstract val right: PropertyId
    abstract val name: String

    context(Context)
    fun createCondition(signe: String): String {
        if (inlineElements.containsKey(left) && inlineElements.containsKey(right)) {
            return "(${inlineElements[left]!!}  $signe ${inlineElements[right]!!})"

        }
        return ""
    }

    override fun allDependencyParsed(parsedElements: Set<String>) =
        parsedElements.containsAll(listOf(left, right))
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
    context(Context)
    override fun use() = createCondition("==")
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
    context(Context)
    override fun use() = createCondition(">=")
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
    context(Context)
    override fun use() = createCondition(">")
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
    context(Context)
    override fun use() = createCondition("<")
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
    context(Context)
    override fun use() = createCondition("<=")
}