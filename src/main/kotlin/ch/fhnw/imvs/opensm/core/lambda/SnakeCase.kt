package ch.fhnw.imvs.opensm.core.lambda

import com.samskivert.mustache.Mustache
import com.samskivert.mustache.Template
import java.io.Writer

class SnakeCase : Mustache.Lambda {

    override fun execute(frag: Template.Fragment, out: Writer) =
        out.write(frag.execute().toSnakeCase())
}

fun String.toSnakeCase() = split(' ').joinToString(separator = "_") { it.uppercase() }