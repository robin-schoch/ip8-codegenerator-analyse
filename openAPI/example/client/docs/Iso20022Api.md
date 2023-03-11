# Iso20022Api

All URIs are relative to *http://payment.common-api.ch*

Method | HTTP request | Description
------------- | ------------- | -------------
[**iso20022PaymentsPost**](Iso20022Api.md#iso20022PaymentsPost) | **POST** /iso20022/payments | Submit ISO20022 XML payment instruction (PAIN.001)
[**iso20022PaymentsSubmissionIdDelete**](Iso20022Api.md#iso20022PaymentsSubmissionIdDelete) | **DELETE** /iso20022/payments/{submissionId} | Delete a submitted ISO20022 XML PAIN.001 message before execution
[**iso20022PaymentsSubmissionIdGet**](Iso20022Api.md#iso20022PaymentsSubmissionIdGet) | **GET** /iso20022/payments/{submissionId} | Retrieve a submitted ISO20022 XML PAIN.001 message
[**iso20022PaymentsSubmissionIdStatusGet**](Iso20022Api.md#iso20022PaymentsSubmissionIdStatusGet) | **GET** /iso20022/payments/{submissionId}/status | Get the ISO20022 XML status report (PAIN.002) for a specific payment instruction


<a name="iso20022PaymentsPost"></a>
# **iso20022PaymentsPost**
> iso20022PaymentsPost(authorization, xCorAPIClientID, xCorrelationID, userAgent, body, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Submit ISO20022 XML payment instruction (PAIN.001)

Submit an XML PAIN.001 payment instruction according to the ISO20022 specification.

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = Iso20022Api()
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val body : kotlin.String = body_example // kotlin.String | The XML PAIN.001.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    apiInstance.iso20022PaymentsPost(authorization, xCorAPIClientID, xCorrelationID, userAgent, body, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
} catch (e: ClientException) {
    println("4xx response calling Iso20022Api#iso20022PaymentsPost")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling Iso20022Api#iso20022PaymentsPost")
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
 **body** | **kotlin.String**| The XML PAIN.001. |
 **xCorAPITargetID** | **kotlin.String**| ID of the target, e.g., a financial institution. (SCOPE: FI - optional) | [optional]
 **xPSUIPAddress** | **kotlin.String**| IP address of the user initiating the operation (SCOPE: FI - optional) | [optional]
 **xPSUUserAgent** | **kotlin.String**| User of the client software (SCOPE: FI - optional) | [optional]

### Return type

null (empty response body)

### Authorization


Configure OAuth2:
    ApiClient.accessToken = ""

### HTTP request headers

 - **Content-Type**: application/xml
 - **Accept**: application/problem+json

<a name="iso20022PaymentsSubmissionIdDelete"></a>
# **iso20022PaymentsSubmissionIdDelete**
> iso20022PaymentsSubmissionIdDelete(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Delete a submitted ISO20022 XML PAIN.001 message before execution

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = Iso20022Api()
val submissionID : kotlin.String = submissionId // kotlin.String | ID of payment submission to be retrieved.
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    apiInstance.iso20022PaymentsSubmissionIdDelete(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
} catch (e: ClientException) {
    println("4xx response calling Iso20022Api#iso20022PaymentsSubmissionIdDelete")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling Iso20022Api#iso20022PaymentsSubmissionIdDelete")
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

<a name="iso20022PaymentsSubmissionIdGet"></a>
# **iso20022PaymentsSubmissionIdGet**
> kotlin.String iso20022PaymentsSubmissionIdGet(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Retrieve a submitted ISO20022 XML PAIN.001 message

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = Iso20022Api()
val submissionID : kotlin.String = submissionId // kotlin.String | ID of payment submission to be retrieved.
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    val result : kotlin.String = apiInstance.iso20022PaymentsSubmissionIdGet(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
    println(result)
} catch (e: ClientException) {
    println("4xx response calling Iso20022Api#iso20022PaymentsSubmissionIdGet")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling Iso20022Api#iso20022PaymentsSubmissionIdGet")
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

**kotlin.String**

### Authorization


Configure OAuth2:
    ApiClient.accessToken = ""

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/xml, application/problem+json

<a name="iso20022PaymentsSubmissionIdStatusGet"></a>
# **iso20022PaymentsSubmissionIdStatusGet**
> kotlin.String iso20022PaymentsSubmissionIdStatusGet(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Get the ISO20022 XML status report (PAIN.002) for a specific payment instruction

The status report for the requested XML ISO20022 payment instruction (PAIN.002).

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = Iso20022Api()
val submissionID : kotlin.String = submissionId // kotlin.String | ID of payment submission to be retrieved.
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    val result : kotlin.String = apiInstance.iso20022PaymentsSubmissionIdStatusGet(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
    println(result)
} catch (e: ClientException) {
    println("4xx response calling Iso20022Api#iso20022PaymentsSubmissionIdStatusGet")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling Iso20022Api#iso20022PaymentsSubmissionIdStatusGet")
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

**kotlin.String**

### Authorization


Configure OAuth2:
    ApiClient.accessToken = ""

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/xml, application/problem+json

