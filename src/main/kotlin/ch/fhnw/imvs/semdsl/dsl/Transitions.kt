package ch.fhnw.imvs.semdsl.dsl

import ch.fhnw.imvs.semdsl.stage2.*
import kotlinx.serialization.Serializable


typealias TransitionId = String

@Serializable
data class Transition(
    val id: TransitionId,
    val event: EventId,
    val invocations: List<InvocationId>,
    val source: StateId,
    val target: StateId?
) : StateMachinableItem, TransitionableItem {

    override fun buildStateMachineEntry(): StateMachineItem {
        return StateMachineItem(id) { items, stateMachineItems ->
            val callableEvent = items[event] ?: error("Event does not exist")
            val callableTarget = stateMachineItems[target]

            val callableInvocations =
                invocations.map { items[it] ?: error("invocation does not exist") }
                    .map { it.call(items, listOf()) }
                    .fold("") { acc, it ->
                        """
                $it""" + acc
                    }

            if (callableInvocations.isNullOrBlank() && callableTarget == null) return@StateMachineItem listOf()

            """
            if (${callableEvent.call(items, listOf())})
            {
                $callableInvocations
                ${
                if (callableTarget != null) "return ${
                    callableTarget.definition(items, stateMachineItems).first()
                };" else ""
            }
            }
            """.trimIndent().split("\n")
        }
    }

    override fun buildTransition(): TransitionItem {
        return TransitionItem(id, source)
    }

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

    override fun getKey(): String {
        return id
    }


}

