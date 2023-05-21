---
sidebar_label: Tinder StateMachine
title: Tinder StateMachine
sidebar_position: 2
---

# TinderState Machine

This section explains how to generate source code for the Tinder StateMachine framework and how to use it for a
project.

## Run with Gradle

To run the Tinder StateMachine Generator execute the following gradle task:

```bash
./gradlew generateForTinderStateMachine 
```

Optionally you can provide the following properties:

| Property | Description                | Default Value                                                                                 |
|----------|----------------------------|-----------------------------------------------------------------------------------------------|
| `in`     | The path to the input file | "/Users/robin/Documents/GitHub/ip8-codegenerator-analyse/src/main/resources/spec/opensm.json" |
| `g`      | The generator to be used   | "kotlin-tinder"                                                                               |
| `pn`     | The name of the project    | "tinder-open-statemachine"                                                                    |

These properties can be overridden when running the Gradle task from the command line using the `-P` option, like this:

```bash
./gradlew generateForTinderStateMachine -PinputPath=new_input_path -Pgenerator=new_generator -PprojectName=new_project_name
```

Replace `new_input_path`, `new_generator`, and `new_project_name` with your actual new arguments.

## Run with Intelij Run Config

If you use Intelij you are able to import this project. After successfully importing it you may run the __Open CMD
Kotlin Tinder__ run config.
Optionally you may adjust parameters by editing the run config itself. You may change the following properties

| Property | Description                | Default Value                                                                                 |
|----------|----------------------------|-----------------------------------------------------------------------------------------------|
| `in`     | The path to the input file | "/Users/robin/Documents/GitHub/ip8-codegenerator-analyse/src/main/resources/spec/opensm.json" |
| `g`      | The generator to be used   | "kotlin-tinder"                                                                               |
| `pn`     | The name of the project    | "tinder-open-statemachine"                                                                    |