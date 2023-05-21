---
sidebar_label: Spring State Machine
title: Spring State Machine
sidebar_position: 1
---

# Spring State Machine

This section explains how to generate source code for the spring state machine framework and how to use it for a
project.

## Run with Gradle

To run the Spring State Machine Generator execute the following gradle task:

```bash
./gradlew generateForSpringStateMachine 
```

Optionally you can provide the following properties:

| Property | Description                | Default Value                          |
|----------|----------------------------|----------------------------------------|
| `in`     | The path to the input file | "/src/main/resources/spec/opensm.json" |
| `g`      | The generator to be used   | "java-spring"                          |
| `pn`     | The name of the project    | "spring-open-statemachine"             |

These properties can be overridden when running the Gradle task from the command line using the `-P` option, like this:

```bash
./gradlew generateForSpringStateMachine -PinputPath=new_input_path -Pgenerator=new_generator -PprojectName=new_project_name
```

Replace `new_input_path`, `new_generator`, and `new_project_name` with your actual new arguments.

## Run with Intelij Run Config

If you use Intelij you are able to import this project. After successfully importing it you may run the __Open CMD Java
Spring__ run config.
Optionally you may adjust parameters by editing the run config itself. You may change the following properties

| Property | Description                | Default Value                                                                                 |
|----------|----------------------------|-----------------------------------------------------------------------------------------------|
| `in`     | The path to the input file | "/Users/robin/Documents/GitHub/ip8-codegenerator-analyse/src/main/resources/spec/opensm.json" |
| `g`      | The generator to be used   | "java-spring"                                                                                 |
| `pn`     | The name of the project    | "spring-open-statemachine"                                                                    |