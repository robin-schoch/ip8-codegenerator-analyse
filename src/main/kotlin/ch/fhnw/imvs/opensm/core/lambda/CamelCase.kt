package ch.fhnw.imvs.opensm.core.lambda

import com.samskivert.mustache.Mustache
import com.samskivert.mustache.Template
import java.io.Writer

class CamelCase : Mustache.Lambda {

    override fun execute(frag: Template.Fragment, out: Writer) =
        out.write(frag.execute().split(' ').joinToString(separator = "") { it.first().uppercase() + it.drop(1) })
}
