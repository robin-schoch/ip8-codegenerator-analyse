package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.Context
import kotlinx.serialization.Serializable


typealias TransitionId = String

@Serializable
data class Transition(
    val id: TransitionId,
    val event: EventId,
    val invocations: List<InvocationId>,
    val source: StateId,
    val target: StateId?
) {

    context(Context)
    fun use(): List<String> {

        if (inlineInvocations().isEmpty() && stateContext[target] == null) {
            return listOf()
        }

        return """
       if (${eventContext[event]!!.use})
       {
           ${inlineInvocations()}
           ${stateContext[target].let { if (it != null) "return $it;" else "" }}
       }
    """.trimIndent().split("\n")
    }

    context(Context)
    private fun inlineInvocations() =
        invocations.fold("") { acc, it ->
            """
           ${inlineElements[it]}""" + acc
        }
}

