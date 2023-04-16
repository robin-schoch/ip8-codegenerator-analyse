package ch.fhnw.imvs.opensm.core.lambda

import com.samskivert.mustache.Mustache
import com.samskivert.mustache.Template
import java.io.Writer

class Capitalize : Mustache.Lambda {

    override fun execute(frag: Template.Fragment, out: Writer) = frag.execute().let {
        out.write(it.toCapitalize())
    }
}

fun String.toCapitalize() = "${take(1).uppercase()}${drop(1)}"