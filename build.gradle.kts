import org.jetbrains.kotlin.gradle.tasks.KotlinCompile

val kotlin_version: String by project

plugins {
    kotlin("jvm") version "1.7.20"
    kotlin("plugin.serialization") version "1.7.20"
}

group = "ch.fhnw.imvs"
version = "1.0-SNAPSHOT"

repositories {
    mavenCentral()
}


dependencies {
    implementation("app.cash.barber:barber:0.3.3")
    implementation("com.github.spullara.mustache.java:compiler:0.9.10")
    implementation("org.jetbrains.kotlinx:kotlinx-serialization-json:1.4.1")
    implementation("org.jetbrains.kotlinx:kotlinx-coroutines-core:1.6.4")
    implementation("org.jetbrains.kotlinx:kotlinx-cli:0.3.5")
    implementation("org.jetbrains.kotlin:kotlin-reflect:1.8.0")
    testImplementation(kotlin("test"))
}

tasks.test {
    useJUnitPlatform()
}

tasks.withType<KotlinCompile> {
    kotlinOptions.jvmTarget = "1.8"
    kotlinOptions.languageVersion = "1.8"
    kotlinOptions.freeCompilerArgs = listOf("-Xcontext-receivers")
}