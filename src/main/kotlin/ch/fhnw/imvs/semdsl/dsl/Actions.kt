package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.InlineItem
import ch.fhnw.imvs.semdsl.stage2.InlineItems
import ch.fhnw.imvs.semdsl.stage2.InlineableItem
import kotlinx.serialization.ExperimentalSerializationApi
import kotlinx.serialization.SerialName
import kotlinx.serialization.Serializable
import kotlinx.serialization.json.JsonClassDiscriminator
import kotlinx.serialization.modules.SerializersModule
import kotlinx.serialization.modules.polymorphic
import kotlinx.serialization.modules.subclass

typealias ActionId = String

@OptIn(ExperimentalSerializationApi::class)
val actionSerializersModule = SerializersModule {
    polymorphic(Action::class) {
        subclass(Template::class)
        defaultDeserializer { Template.serializer() }
    }
}

@OptIn(ExperimentalSerializationApi::class)
@Serializable
@JsonClassDiscriminator("id")
sealed class Action : InlineableItem {
    abstract val id: ActionId
    abstract val name: String
    abstract val description: String
    abstract val hardcoded: Boolean
    abstract val parameters: List<ParameterId>
    abstract val constraints: List<List<String>>

    open fun use(inlineElements: List<String>): String = ""
    override fun getKey(): String {
        return id
    }

}

@Serializable
data class Template(
    override val id: ActionId,
    override val name: String,
    override val description: String,
    override val hardcoded: Boolean,
    override val parameters: List<ParameterId>,
    override val constraints: List<List<String>>
) : Action() {
    override fun use(inlineElements: List<String>): String = "TODO()"
    override fun buildCall(): InlineItem {
        return InlineItem(id) { _, _ -> "// TODO implement templates" }
    }
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
    override fun use(inlineElements: List<String>): String =
        "${inlineElements[0]}.Start()"

    override fun buildCall(): InlineItem {
        return InlineItem(id) { items: InlineItems, actionParams ->
            val timer = if (actionParams.isNotEmpty()) {
                items[actionParams.first()] ?: error("Parameter with id ${actionParams.first()} does not exist")
            } else error("Missing parameter for StartTimerActionHandler")
            "${timer.call(items, actionParams)}.Start()"
        }
    }
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
    override fun use(inlineElements: List<String>): String =
        """
            if(${inlineElements[0]}) {
                ${inlineElements[1]}
            }
        """.trimIndent()

    override fun buildCall(): InlineItem {
        return InlineItem(id) { items: InlineItems, actionParams ->
            val (condition, action) = if (actionParams.size >= 2) {
                actionParams.map { items[it] ?: error("Parameter with id ${actionParams.first()} does not exist") }
            } else error("Missing parameter for InvokeIf Action")
            """
            if(${condition.call(items, actionParams)}) {
                ${action.call(items, actionParams)}
            }
            """.trimIndent()
        }
    }
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
    override fun use(inlineElements: List<String>): String =
        "${inlineElements[0]} -= ${inlineElements[1]};"

    override fun buildCall(): InlineItem {
        return InlineItem(id) { items: InlineItems, actionParams ->
            val (subtractee, subtractor) = if (actionParams.size >= 2) {
                actionParams.map { items[it] ?: error("Parameter with id ${actionParams.first()} does not exist") }
            } else error("Missing parameter for Subtract Action")
            "${subtractee.call(items, actionParams)} -= ${subtractor.call(items, actionParams)};"
        }
    }
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
    override fun use(inlineElements: List<String>): String =
        "${inlineElements[0]} += ${inlineElements[1]};"

    override fun buildCall(): InlineItem {
        return InlineItem(id) { items: InlineItems, actionParams ->
            val (addee, addor) = if (actionParams.size >= 2) {
                actionParams.map { items[it] ?: error("Parameter with id ${actionParams.first()} does not exist") }
            } else error("Missing parameter for Add Action")
            "${addee.call(items, actionParams)} -= ${addor.call(items, actionParams)};"
        }
    }
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
    override fun use(inlineElements: List<String>): String =
        "${inlineElements[0]}--;"

    override fun buildCall(): InlineItem {
        return InlineItem(id) { items: InlineItems, actionParams ->
            val number = if (actionParams.isNotEmpty()) {
                items[actionParams.first()] ?: error("Parameter with id ${actionParams.first()} does not exist")
            } else error("Missing parameter for Decrement")
            "${number.call(items, actionParams)}--;"
        }
    }
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
    override fun use(inlineElements: List<String>): String =
        "${inlineElements[0]}++;"

    override fun buildCall(): InlineItem {
        return InlineItem(id) { items: InlineItems, actionParams ->
            val number = if (actionParams.isNotEmpty()) {
                items[actionParams.first()] ?: error("Parameter with id ${actionParams.first()} does not exist")
            } else error("Missing parameter for Increment")
            "${number.call(items, actionParams)}++;"
        }
    }
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
    override fun use(inlineElements: List<String>): String =
        "${inlineElements[0]} = 0;"

    override fun buildCall(): InlineItem {
        return InlineItem(id) { items: InlineItems, actionParams ->
            val number = if (actionParams.isNotEmpty()) {
                items[actionParams.first()] ?: error("Parameter with id ${actionParams.first()} does not exist")
            } else error("Missing parameter for Zero Action")
            "${number.call(items, actionParams)} = 0;"
        }
    }
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
    override fun use(inlineElements: List<String>): String =
        "${inlineElements[0]} = ${inlineElements[1]};"

    override fun buildCall(): InlineItem {
        return InlineItem(id) { items: InlineItems, actionParams ->
            val (assignee, assignor) = if (actionParams.size >= 2) {
                actionParams.map { items[it] ?: error("Parameter with id ${actionParams.first()} does not exist") }
            } else error("Missing parameter for Assign Action")
            "${assignee.call(items, actionParams)} = ${assignor.call(items, actionParams)};"
        }
    }
}