---
sidebar_label: Stage 1
title: Stage 1
sidebar_position: 1
---

# Stage 1 Swissframe Code Generator

This sections explians how to generate source code for the stage 1 Swissframe Code Generator.

## Run with Gradle

To run the Stage 1 generator execute the following gradle task:

```bash
./gradlew generateStage1
```

Optionally you can provide the following properties:
var inputPath = "json/state.json"
var outputDir = "./output/generator"

| Property | Description                | Default Value        |
|----------|----------------------------|----------------------|
| `in`     | The path to the input file | "json/state.json"    |
| `out`    | The output directory       | "./output/generator" |

These properties can be overridden when running the Gradle task from the command line using the `-P` option, like this:

```bash
./gradlew generateStage1 -Pin=new_input_paht Pout=new_out_directory
```

## Run with Intelij Run Config

If you use Intelij you are able to import this project. After successfully importing it you may run the __Generate C#
JSON__ run config.
Optionally you may adjust parameters by editing the run config itself. You may change the following properties

| Property | Description                | Default Value        |
|----------|----------------------------|----------------------|
| `in`     | The path to the input file | "json/state.json"    |
| `out`    | The output directory       | "./output/generator" |
| `G`      | Select Generator           | "CSharpGenerator"    |