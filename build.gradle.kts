import org.jetbrains.kotlin.gradle.tasks.KotlinCompile

val kotlin_version: String by project
val semver_version: String by project
val logging_version: String by project

plugins {
    kotlin("jvm") version "1.8.20"
    kotlin("plugin.serialization") version "1.8.20"
}

group = "ch.fhnw.imvs"
version = "1.0-SNAPSHOT"

repositories {
    mavenCentral()
}

dependencies {
    implementation("com.tinder.statemachine:statemachine:0.2.0")
    implementation("app.cash.barber:barber:0.3.3")
    implementation("com.github.spullara.mustache.java:compiler:0.9.10")
    implementation("com.samskivert:jmustache:1.15")
    implementation("org.jetbrains.kotlinx:kotlinx-serialization-json:1.4.1")
    implementation("org.jetbrains.kotlinx:kotlinx-coroutines-core:1.6.4")
    implementation("org.jetbrains.kotlinx:kotlinx-cli:0.3.5")
    implementation("org.jetbrains.kotlin:kotlin-reflect:1.8.0")
    implementation("org.jetbrains.kotlinx:kotlinx-datetime:0.4.0")
    implementation("io.github.z4kn4fein:semver:$semver_version")
    implementation("io.github.oshai:kotlin-logging-jvm:$logging_version")
    implementation("org.springframework.statemachine:spring-statemachine-core:3.2.0")
    implementation("org.springframework:spring-context:6.0.6")
    testImplementation(kotlin("test"))
    implementation("org.mapstruct:mapstruct:1.5.3.Final")
    annotationProcessor("org.mapstruct:mapstruct-processor:1.5.3.Final")
    implementation("org.springframework.boot:spring-boot-starter-parent:3.0.5")
    implementation("org.springframework.boot:spring-boot-starter:3.0.5")
}

tasks.test {
    useJUnitPlatform()
}

tasks.withType<KotlinCompile> {
    kotlinOptions.jvmTarget = "1.8"
    kotlinOptions.languageVersion = kotlin_version
    kotlinOptions.freeCompilerArgs = listOf("-Xcontext-receivers")
}

tasks.register<JavaExec>("generateForSpringStateMachine") {
    main = "ch.fhnw.imvs.opensm.api.CommandLineKt"
    classpath = sourceSets["main"].runtimeClasspath
    // Default arguments
    var inputPath = "/Users/robin/Documents/GitHub/ip8-codegenerator-analyse/src/main/resources/spec/opensm.json"
    var generator = "java-spring"
    var projectName = "spring-open-statemachine"

    // Overwrite with project properties from command line if present
    if (project.hasProperty("in")) {
        inputPath = project.property("in") as String
    }
    if (project.hasProperty("g")) {
        generator = project.property("g") as String
    }
    if (project.hasProperty("pn")) {
        projectName = project.property("pn") as String
    }
    args = listOf("-in", inputPath, "-g", generator, "-pn", projectName)
}

tasks.register<JavaExec>("generateForTinderStateMachine") {
    main = "ch.fhnw.imvs.opensm.api.CommandLineKt"
    classpath = sourceSets["main"].runtimeClasspath
    // Default arguments
    var inputPath = "/Users/robin/Documents/GitHub/ip8-codegenerator-analyse/src/main/resources/spec/opensm.json"
    var generator = "kotlin-tinder"
    var projectName = "tinder-open-statemachine"

    // Overwrite with project properties from command line if present
    if (project.hasProperty("in")) {
        inputPath = project.property("in") as String
    }
    if (project.hasProperty("g")) {
        generator = project.property("g") as String
    }
    if (project.hasProperty("pn")) {
        projectName = project.property("pn") as String
    }
    args = listOf("-in", inputPath, "-g", generator, "-pn", projectName)
}