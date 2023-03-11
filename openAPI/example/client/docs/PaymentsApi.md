# PaymentsApi

All URIs are relative to *http://payment.common-api.ch*

Method | HTTP request | Description
------------- | ------------- | -------------
[**paymentsGet**](PaymentsApi.md#paymentsGet) | **GET** /payments | Get the list of all payments.
[**paymentsPost**](PaymentsApi.md#paymentsPost) | **POST** /payments | Initiate new payments submission
[**paymentsSubmissionIdDelete**](PaymentsApi.md#paymentsSubmissionIdDelete) | **DELETE** /payments/{submissionId} | Delete a specific payment submission before executed
[**paymentsSubmissionIdGet**](PaymentsApi.md#paymentsSubmissionIdGet) | **GET** /payments/{submissionId} | Get a specific payment submission
[**paymentsSubmissionIdStatusGet**](PaymentsApi.md#paymentsSubmissionIdStatusGet) | **GET** /payments/{submissionId}/status | Get status information for the specific payment submission


<a name="paymentsGet"></a>
# **paymentsGet**
> PaymentsGet200Response paymentsGet(authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Get the list of all payments.

Return the list of all payments for the authenticated context.

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = PaymentsApi()
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    val result : PaymentsGet200Response = apiInstance.paymentsGet(authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
    println(result)
} catch (e: ClientException) {
    println("4xx response calling PaymentsApi#paymentsGet")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling PaymentsApi#paymentsGet")
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

[**PaymentsGet200Response**](PaymentsGet200Response.md)

### Authorization


Configure OAuth2:
    ApiClient.accessToken = ""

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

<a name="paymentsPost"></a>
# **paymentsPost**
> paymentsPost(authorization, xCorAPIClientID, xCorrelationID, userAgent, paymentSubmissionRequest, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Initiate new payments submission

Create new payments submission.

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = PaymentsApi()
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val paymentSubmissionRequest : PaymentSubmissionRequest =  // PaymentSubmissionRequest | Details of payments submission to be added.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    apiInstance.paymentsPost(authorization, xCorAPIClientID, xCorrelationID, userAgent, paymentSubmissionRequest, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
} catch (e: ClientException) {
    println("4xx response calling PaymentsApi#paymentsPost")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling PaymentsApi#paymentsPost")
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
 **paymentSubmissionRequest** | [**PaymentSubmissionRequest**](PaymentSubmissionRequest.md)| Details of payments submission to be added. |
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

<a name="paymentsSubmissionIdDelete"></a>
# **paymentsSubmissionIdDelete**
> paymentsSubmissionIdDelete(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Delete a specific payment submission before executed

Delete a specific payment submission before executed.

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = PaymentsApi()
val submissionID : kotlin.String = submissionId // kotlin.String | ID of payment submission to be retrieved.
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    apiInstance.paymentsSubmissionIdDelete(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
} catch (e: ClientException) {
    println("4xx response calling PaymentsApi#paymentsSubmissionIdDelete")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling PaymentsApi#paymentsSubmissionIdDelete")
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

<a name="paymentsSubmissionIdGet"></a>
# **paymentsSubmissionIdGet**
> PaymentSubmissionRequest paymentsSubmissionIdGet(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Get a specific payment submission

Retrieve a specific payment submission.

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = PaymentsApi()
val submissionID : kotlin.String = submissionId // kotlin.String | ID of payment submission to be retrieved.
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    val result : PaymentSubmissionRequest = apiInstance.paymentsSubmissionIdGet(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
    println(result)
} catch (e: ClientException) {
    println("4xx response calling PaymentsApi#paymentsSubmissionIdGet")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling PaymentsApi#paymentsSubmissionIdGet")
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

[**PaymentSubmissionRequest**](PaymentSubmissionRequest.md)

### Authorization


Configure OAuth2:
    ApiClient.accessToken = ""

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

<a name="paymentsSubmissionIdStatusGet"></a>
# **paymentsSubmissionIdStatusGet**
> PaymentSubmissionStatus paymentsSubmissionIdStatusGet(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Get status information for the specific payment submission

Retrieve a specific payment submission&#39;s status.

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = PaymentsApi()
val submissionID : kotlin.String = submissionId // kotlin.String | ID of payment submission to be retrieved.
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    val result : PaymentSubmissionStatus = apiInstance.paymentsSubmissionIdStatusGet(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
    println(result)
} catch (e: ClientException) {
    println("4xx response calling PaymentsApi#paymentsSubmissionIdStatusGet")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling PaymentsApi#paymentsSubmissionIdStatusGet")
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

[**PaymentSubmissionStatus**](PaymentSubmissionStatus.md)

### Authorization


Configure OAuth2:
    ApiClient.accessToken = ""

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

