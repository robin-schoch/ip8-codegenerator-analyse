# OpenAPI Generate

This is an Open API generator example

## Install OpenAPI generator

The easiest way to install is with npm.

```
npm install @openapitools/openapi-generator-cli -g
```

## Generate server code

```
npx @openapitools/openapi-generator-cli generate -i ./paymentAPI.yaml -g kotlin-server -o ./example/server
```

```
npx @openapitools/openapi-generator-cli generate -i ./paymentAPI.yaml -g kotlin -o ./example/client --additional-properties=library=jvm-ktor
```
