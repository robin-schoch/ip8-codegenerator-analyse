package ch.fhnw.imvs.opensm.core

import ch.fhnw.imvs.opensm.core.model.PrimitiveTyp

interface PrimitiveResolver {
    fun primitiveOf(value: PrimitiveTyp): String

    fun defaultValueOf(value: PrimitiveTyp, default: String): String
}
