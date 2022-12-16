package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.Context
import kotlinx.serialization.Serializable

typealias EventId = String

@Serializable
data class Event(
    val id: EventId,
    val check: String
) {
    context(Context) fun use(name: String): String =
        """
        private bool $name
        {
            var result = ${termContext[check]!!}
            return result;
        } 
        """.trimIndent()
}

