package ch.fhnw.imvs.semdsl.dsl

import kotlinx.serialization.SerialName
import kotlinx.serialization.Serializable
import java.time.LocalDateTime


typealias PropertyId = String

@Serializable(with = PropertySourceSerializer::class)
enum class PropertySource(val formattedName: String) {
    CONSTANT("Constant"),
    SENSOR("Sensor"),
    VARIABLE("Variable"),
    TIMER("Timer"),
    CONFIG("Config");
}


@Serializable
sealed class Property {
    abstract val id: PropertyId
    abstract val name: String
    abstract val hardcoded: Boolean
    abstract val source: PropertySource
    abstract val type: String
    abstract val unit: String?
    abstract val value: Any?

    fun statement(): String {
        return when (source) {
            PropertySource.CONSTANT -> constantStatement()
            PropertySource.SENSOR -> sensorStatement()
            PropertySource.VARIABLE -> variableStatement()
            PropertySource.TIMER -> timerStatement()
            PropertySource.CONFIG -> configStatement()
        }
    }

    open fun constantStatement(): String {
        throw UnsupportedOperationException("property cannot be used as a constant")
    }

    open fun sensorStatement(): String {
        throw UnsupportedOperationException("property cannot be used as a sensor")
    }

    open fun variableStatement(): String {
        throw UnsupportedOperationException("property cannot be used as a variable")
    }

    open fun timerStatement(): String {
        throw UnsupportedOperationException("property cannot be used as a timer")
    }

    open fun configStatement(): String {
        throw UnsupportedOperationException("property cannot be used as a config")
    }
}

@Serializable
@SerialName("d160efb7-5e99-4015-a4c9-3cad8e22c811")
class UIntProperty(
    override val id: PropertyId,
    override val name: String,
    override val hardcoded: Boolean,
    override val source: PropertySource,
    override val type: String,
    override val value: Int? = null,
    override val unit: String? = null,
) : Property() {

    override fun variableStatement(): String {
        return "public uint ${source.formattedName}_$name { get; set; }"
    }
}

@Serializable
@SerialName("9cde95f8-3853-43ba-b161-2b8c2094e193")
class IntProperty(
    override val id: PropertyId,
    override val name: String,
    override val hardcoded: Boolean,
    override val source: PropertySource,
    override val type: String,
    override val value: Int? = null,
    override val unit: String? = null,
) : Property()

@Serializable
@SerialName("79e69aae-3db9-4410-b5df-4dd7eeb1271c")
class BooleanProperty(
    override val id: PropertyId,
    override val name: String,
    override val hardcoded: Boolean,
    override val source: PropertySource,
    override val type: String,
    override val value: Boolean? = null,
    override val unit: String? = null,
) : Property() {
    override fun variableStatement(): String {
        return "public bool ${source.formattedName}_$name} { get; set; }"
    }
}

@Serializable
@SerialName("23f2447f-dc0e-40d1-bc7d-757695ec2828")
class DoubleProperty(
    override val id: PropertyId,
    override val name: String,
    override val hardcoded: Boolean,
    override val source: PropertySource,
    override val type: String,
    override val value: Double? = null,
    override val unit: String? = null,
) : Property()

@Serializable
@SerialName("b62d430d-0ef5-4c6d-b1f8-c3f763007e0c")
class StringProperty(
    override val id: PropertyId,
    override val name: String,
    override val hardcoded: Boolean,
    override val source: PropertySource,
    override val type: String,
    override val value: String? = null,
    override val unit: String? = null,
) : Property()

@Serializable
@SerialName("57fc00d3-a2df-4d96-9497-d9a63ebf3f25")
class ListProperty(
    override val id: PropertyId,
    override val name: String,
    override val hardcoded: Boolean,
    override val source: PropertySource,
    override val type: String,
    override val value: List<String>? = listOf(),
    override val unit: String? = null,
) : Property() {

}

@Serializable
@SerialName("3ae2c8e1-9f10-40d5-b6fb-b28216130e7a")
class DateTimeProperty(
    override val id: PropertyId,
    override val name: String,
    override val hardcoded: Boolean,
    override val source: PropertySource,
    override val type: String,
    override val value: String? = null,
    override val unit: String? = null,
) : Property()

@Serializable
@SerialName("41d40f6c-cabc-45af-815d-6d69956bb728")
class DateTimeNowProperty(
    override val id: PropertyId,
    override val name: String,
    override val hardcoded: Boolean,
    override val source: PropertySource,
    override val type: String,
    override val value: String? = LocalDateTime.now().toString(),
    override val unit: String? = null,
) : Property()

@Serializable
@SerialName("91da6a73-fc04-402b-baae-ba3ab7fca376")
class TimerProperty(
    override val id: PropertyId,
    override val name: String,
    override val hardcoded: Boolean,
    override val source: PropertySource,
    override val type: String,
    override val value: String? = "Timer",
    override val unit: String? = null,
) : Property() {

    override fun timerStatement(): String {
        return "public ITimer ${source.formattedName}_$name { get; } "
    }
}

@Serializable(with = HeapPumpSerializer::class)
enum class HeapPump() {
    NONE,
    LEVEL_2,
    LEVEL_3,
    DEFROST_OR_DRIP_OFF;
}

@Serializable
@SerialName("5ea7f8d3-650b-4c70-96dd-082681bd455e")
class HeapPumpNowProperty(
    override val id: PropertyId,
    override val name: String,
    override val hardcoded: Boolean,
    override val source: PropertySource,
    override val type: String,
    override val value: HeapPump? = null,
    override val unit: String = LocalDateTime.now().toString(),
) : Property() {
    override fun constantStatement(): String {
        return ""
    }
}
