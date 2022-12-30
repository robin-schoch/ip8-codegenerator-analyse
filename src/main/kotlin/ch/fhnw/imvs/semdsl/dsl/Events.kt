package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.*
import kotlinx.serialization.Serializable

typealias EventId = String

@Serializable
data class Event(
    val id: EventId,
    val check: String
) : InlineableItem, StateMachinableItem {
    context(Context) fun use(name: String): List<String> =
        """
        private bool $name
        {
            var result = ${inlineElements[check]!!};
            _logger.LogDebug("Event: $name ($id) evaluates to {result}", result);
            return result;
        } 
        """.trimIndent().split("\n")

    override fun getKey(): String {
        return id
    }

    override fun buildCall(): InlineItem {
        return InlineItem(id) { _, _ -> "Event$id()" }
    }


    override fun buildStateMachineEntry(): StateMachineItem {
        return StateMachineItem(id) { items, _ ->
            val checkResult = items[check] ?: error("Check does not exist")
            """
        private bool Event$id()
        {
            var result = ${checkResult.call(items, listOf())};
            _logger.LogDebug("Event: Event$id()($id) evaluates to {result}", result);
            return result;
        } 
        """.trimIndent().split("\n")
        }
    }
}

