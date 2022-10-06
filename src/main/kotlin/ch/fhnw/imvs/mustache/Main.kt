package ch.fhnw.imvs.mustache

import com.github.mustachejava.DefaultMustacheFactory
import com.github.mustachejava.MustacheFactory
import java.io.StringWriter

class Todo {
    val sender: String = "wahtever"
}

fun main() {
    val mf: MustacheFactory = DefaultMustacheFactory()
    val m = mf.compile("template/todo.mustache")
    val todo = Todo()
    val writer = StringWriter()
    m.execute(writer, todo).flush()
    val html: String = writer.toString()
    println(html)
}