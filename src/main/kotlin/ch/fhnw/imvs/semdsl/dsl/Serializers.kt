package ch.fhnw.imvs.semdsl.dsl

import kotlinx.serialization.KSerializer
import kotlinx.serialization.Serializer
import kotlinx.serialization.descriptors.SerialDescriptor
import kotlinx.serialization.descriptors.serialDescriptor
import kotlinx.serialization.encoding.Decoder
import kotlinx.serialization.encoding.Encoder

@Serializer(forClass = PropertySource::class)
object PropertySourceSerializer : KSerializer<PropertySource> {
    override val descriptor: SerialDescriptor = serialDescriptor<String>()
    override fun serialize(output: Encoder, obj: PropertySource) {
        output.encodeString(obj.toString().lowercase())
    }

    override fun deserialize(input: Decoder): PropertySource {
        return PropertySource.valueOf(input.decodeString().uppercase())
    }
}

@Serializer(forClass = HeatPump::class)
object HeatPumpSerializer : KSerializer<HeatPump> {
    override val descriptor: SerialDescriptor = serialDescriptor<String>()
    override fun serialize(output: Encoder, obj: HeatPump) {
        when (obj) {
            HeatPump.NONE -> "3122777f-2b32-4e36-a9ee-e82d3bd7f73b"
            HeatPump.LEVEL_2 -> "1559e7c8-1792-40f0-8fcb-88d459b5999f"
            HeatPump.LEVEL_3 -> "131ac64c-a030-4621-9fe4-aa26b104ee45"
            HeatPump.DEFROST_OR_DRIP_OFF -> "e0a25fc4-7d88-491c-8b3c-67716381e13f"
        }.let { output.encodeString(it) }

    }

    override fun deserialize(input: Decoder): HeatPump {
        return when (input.decodeString()) {
            "3122777f-2b32-4e36-a9ee-e82d3bd7f73b" -> HeatPump.NONE
            "1559e7c8-1792-40f0-8fcb-88d459b5999f" -> HeatPump.LEVEL_2
            "131ac64c-a030-4621-9fe4-aa26b104ee45" -> HeatPump.LEVEL_3
            "e0a25fc4-7d88-491c-8b3c-67716381e13f" -> HeatPump.DEFROST_OR_DRIP_OFF
            else -> HeatPump.NONE
        }

    }
}