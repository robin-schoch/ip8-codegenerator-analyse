# StandingOrdersApi

All URIs are relative to *http://payment.common-api.ch*

Method | HTTP request | Description
------------- | ------------- | -------------
[**standingOrdersGet**](StandingOrdersApi.md#standingOrdersGet) | **GET** /standing-orders | Get the list of all standing orders.
[**standingOrdersPost**](StandingOrdersApi.md#standingOrdersPost) | **POST** /standing-orders | Create a new Standing Order
[**standingOrdersSubmissionIdDelete**](StandingOrdersApi.md#standingOrdersSubmissionIdDelete) | **DELETE** /standing-orders/{submissionId} | Delete a specific standing order submission
[**standingOrdersSubmissionIdGet**](StandingOrdersApi.md#standingOrdersSubmissionIdGet) | **GET** /standing-orders/{submissionId} | Get a specific standing order submission
[**standingOrdersSubmissionIdStatusGet**](StandingOrdersApi.md#standingOrdersSubmissionIdStatusGet) | **GET** /standing-orders/{submissionId}/status | Get status information for the specific standing order submission


<a name="standingOrdersGet"></a>
# **standingOrdersGet**
> StandingOrdersGet200Response standingOrdersGet(authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Get the list of all standing orders.

Return the list of all standing orders for the authenticated context.

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = StandingOrdersApi()
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    val result : StandingOrdersGet200Response = apiInstance.standingOrdersGet(authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
    println(result)
} catch (e: ClientException) {
    println("4xx response calling StandingOrdersApi#standingOrdersGet")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling StandingOrdersApi#standingOrdersGet")
    e.printStackTrace()
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **kotlin.String**| Bearer followed by a base64 encoded OAuth access token |
 **xCorAPIClientID** | **kotlin.String**| ID of the client forwarded to the provider. (SCOPE: FI) |
 **xCorrelationID** | **kotlin.String**| Unique ID (defined by the caller) which will be reflected back in the response. |
 **userAgent** | **kotlin.String**| Name and version of the of the Client software. |
 **xCorAPITargetID** | **kotlin.String**| ID of the target, e.g., a financial institution. (SCOPE: FI - optional) | [optional]
 **xPSUIPAddress** | **kotlin.String**| IP address of the user initiating the operation (SCOPE: FI - optional) | [optional]
 **xPSUUserAgent** | **kotlin.String**| User of the client software (SCOPE: FI - optional) | [optional]

### Return type

[**StandingOrdersGet200Response**](StandingOrdersGet200Response.md)

### Authorization


Configure OAuth2:
    ApiClient.accessToken = ""

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

<a name="standingOrdersPost"></a>
# **standingOrdersPost**
> standingOrdersPost(authorization, xCorAPIClientID, xCorrelationID, userAgent, standingorderSubmissionRequest, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Create a new Standing Order

It is used to create a permanent order for the transfer of funds.

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = StandingOrdersApi()
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val standingorderSubmissionRequest : StandingorderSubmissionRequest =  // StandingorderSubmissionRequest | Details of standing orders submission to be added.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    apiInstance.standingOrdersPost(authorization, xCorAPIClientID, xCorrelationID, userAgent, standingorderSubmissionRequest, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
} catch (e: ClientException) {
    println("4xx response calling StandingOrdersApi#standingOrdersPost")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling StandingOrdersApi#standingOrdersPost")
    e.printStackTrace()
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **kotlin.String**| Bearer followed by a base64 encoded OAuth access token |
 **xCorAPIClientID** | **kotlin.String**| ID of the client forwarded to the provider. (SCOPE: FI) |
 **xCorrelationID** | **kotlin.String**| Unique ID (defined by the caller) which will be reflected back in the response. |
 **userAgent** | **kotlin.String**| Name and version of the of the Client software. |
 **standingorderSubmissionRequest** | [**StandingorderSubmissionRequest**](StandingorderSubmissionRequest.md)| Details of standing orders submission to be added. |
 **xCorAPITargetID** | **kotlin.String**| ID of the target, e.g., a financial institution. (SCOPE: FI - optional) | [optional]
 **xPSUIPAddress** | **kotlin.String**| IP address of the user initiating the operation (SCOPE: FI - optional) | [optional]
 **xPSUUserAgent** | **kotlin.String**| User of the client software (SCOPE: FI - optional) | [optional]

### Return type

null (empty response body)

### Authorization


Configure OAuth2:
    ApiClient.accessToken = ""

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/problem+json

<a name="standingOrdersSubmissionIdDelete"></a>
# **standingOrdersSubmissionIdDelete**
> standingOrdersSubmissionIdDelete(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Delete a specific standing order submission

Delete a specific standing order submission.

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = StandingOrdersApi()
val submissionID : kotlin.String = submissionId // kotlin.String | ID of payment submission to be retrieved.
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    apiInstance.standingOrdersSubmissionIdDelete(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
} catch (e: ClientException) {
    println("4xx response calling StandingOrdersApi#standingOrdersSubmissionIdDelete")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling StandingOrdersApi#standingOrdersSubmissionIdDelete")
    e.printStackTrace()
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **submissionID** | **kotlin.String**| ID of payment submission to be retrieved. |
 **authorization** | **kotlin.String**| Bearer followed by a base64 encoded OAuth access token |
 **xCorAPIClientID** | **kotlin.String**| ID of the client forwarded to the provider. (SCOPE: FI) |
 **xCorrelationID** | **kotlin.String**| Unique ID (defined by the caller) which will be reflected back in the response. |
 **userAgent** | **kotlin.String**| Name and version of the of the Client software. |
 **xCorAPITargetID** | **kotlin.String**| ID of the target, e.g., a financial institution. (SCOPE: FI - optional) | [optional]
 **xPSUIPAddress** | **kotlin.String**| IP address of the user initiating the operation (SCOPE: FI - optional) | [optional]
 **xPSUUserAgent** | **kotlin.String**| User of the client software (SCOPE: FI - optional) | [optional]

### Return type

null (empty response body)

### Authorization


Configure OAuth2:
    ApiClient.accessToken = ""

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/problem+json

<a name="standingOrdersSubmissionIdGet"></a>
# **standingOrdersSubmissionIdGet**
> StandingorderSubmissionRequest standingOrdersSubmissionIdGet(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Get a specific standing order submission

Retrieve a specific standing order submission.

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = StandingOrdersApi()
val submissionID : kotlin.String = submissionId // kotlin.String | ID of payment submission to be retrieved.
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    val result : StandingorderSubmissionRequest = apiInstance.standingOrdersSubmissionIdGet(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
    println(result)
} catch (e: ClientException) {
    println("4xx response calling StandingOrdersApi#standingOrdersSubmissionIdGet")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling StandingOrdersApi#standingOrdersSubmissionIdGet")
    e.printStackTrace()
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **submissionID** | **kotlin.String**| ID of payment submission to be retrieved. |
 **authorization** | **kotlin.String**| Bearer followed by a base64 encoded OAuth access token |
 **xCorAPIClientID** | **kotlin.String**| ID of the client forwarded to the provider. (SCOPE: FI) |
 **xCorrelationID** | **kotlin.String**| Unique ID (defined by the caller) which will be reflected back in the response. |
 **userAgent** | **kotlin.String**| Name and version of the of the Client software. |
 **xCorAPITargetID** | **kotlin.String**| ID of the target, e.g., a financial institution. (SCOPE: FI - optional) | [optional]
 **xPSUIPAddress** | **kotlin.String**| IP address of the user initiating the operation (SCOPE: FI - optional) | [optional]
 **xPSUUserAgent** | **kotlin.String**| User of the client software (SCOPE: FI - optional) | [optional]

### Return type

[**StandingorderSubmissionRequest**](StandingorderSubmissionRequest.md)

### Authorization


Configure OAuth2:
    ApiClient.accessToken = ""

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

<a name="standingOrdersSubmissionIdStatusGet"></a>
# **standingOrdersSubmissionIdStatusGet**
> StandingorderSubmissionStatus standingOrdersSubmissionIdStatusGet(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Get status information for the specific standing order submission

Retrieve a specific standing order submission&#39;s status.

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = StandingOrdersApi()
val submissionID : kotlin.String = submissionId // kotlin.String | ID of payment submission to be retrieved.
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    val result : StandingorderSubmissionStatus = apiInstance.standingOrdersSubmissionIdStatusGet(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
    println(result)
} catch (e: ClientException) {
    println("4xx response calling StandingOrdersApi#standingOrdersSubmissionIdStatusGet")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling StandingOrdersApi#standingOrdersSubmissionIdStatusGet")
    e.printStackTrace()
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **submissionID** | **kotlin.String**| ID of payment submission to be retrieved. |
 **authorization** | **kotlin.String**| Bearer followed by a base64 encoded OAuth access token |
 **xCorAPIClientID** | **kotlin.String**| ID of the client forwarded to the provider. (SCOPE: FI) |
 **xCorrelationID** | **kotlin.String**| Unique ID (defined by the caller) which will be reflected back in the response. |
 **userAgent** | **kotlin.String**| Name and version of the of the Client software. |
 **xCorAPITargetID** | **kotlin.String**| ID of the target, e.g., a financial institution. (SCOPE: FI - optional) | [optional]
 **xPSUIPAddress** | **kotlin.String**| IP address of the user initiating the operation (SCOPE: FI - optional) | [optional]
 **xPSUUserAgent** | **kotlin.String**| User of the client software (SCOPE: FI - optional) | [optional]

### Return type

[**StandingorderSubmissionStatus**](StandingorderSubmissionStatus.md)

### Authorization


Configure OAuth2:
    ApiClient.accessToken = ""

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

