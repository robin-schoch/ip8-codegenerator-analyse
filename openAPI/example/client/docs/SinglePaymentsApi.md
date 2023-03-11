# SinglePaymentsApi

All URIs are relative to *http://payment.common-api.ch*

Method | HTTP request | Description
------------- | ------------- | -------------
[**singlePaymentsGet**](SinglePaymentsApi.md#singlePaymentsGet) | **GET** /single-payments | Get the list of all payments (all payment types)
[**singlePaymentsPost**](SinglePaymentsApi.md#singlePaymentsPost) | **POST** /single-payments | Initiate new single payments submission
[**singlePaymentsSubmissionIdDelete**](SinglePaymentsApi.md#singlePaymentsSubmissionIdDelete) | **DELETE** /single-payments/{submissionId} | Delete a single payment
[**singlePaymentsSubmissionIdGet**](SinglePaymentsApi.md#singlePaymentsSubmissionIdGet) | **GET** /single-payments/{submissionId} | Get a specific payment
[**singlePaymentsSubmissionIdStatusGet**](SinglePaymentsApi.md#singlePaymentsSubmissionIdStatusGet) | **GET** /single-payments/{submissionId}/status | Get status information for the specific single payment


<a name="singlePaymentsGet"></a>
# **singlePaymentsGet**
> SinglePaymentsGet200Response singlePaymentsGet(authorization, xCorAPIClientID, xCorrelationID, userAgent, entryReferenceFrom, limit, dateFrom, dateTo, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Get the list of all payments (all payment types)

Return the list of all initiated payments of all types for the authenticated context.

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = SinglePaymentsApi()
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val entryReferenceFrom : kotlin.String = entryReferenceFrom_example // kotlin.String | Get all objects after the one with the given ID.
val limit : kotlin.Int = 56 // kotlin.Int | Number of items to be returned.
val dateFrom : java.time.LocalDate = 2013-10-20 // java.time.LocalDate | 
val dateTo : java.time.LocalDate = 2013-10-20 // java.time.LocalDate | 
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    val result : SinglePaymentsGet200Response = apiInstance.singlePaymentsGet(authorization, xCorAPIClientID, xCorrelationID, userAgent, entryReferenceFrom, limit, dateFrom, dateTo, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
    println(result)
} catch (e: ClientException) {
    println("4xx response calling SinglePaymentsApi#singlePaymentsGet")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling SinglePaymentsApi#singlePaymentsGet")
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
 **entryReferenceFrom** | **kotlin.String**| Get all objects after the one with the given ID. | [optional]
 **limit** | **kotlin.Int**| Number of items to be returned. | [optional]
 **dateFrom** | **java.time.LocalDate**|  | [optional]
 **dateTo** | **java.time.LocalDate**|  | [optional]
 **xCorAPITargetID** | **kotlin.String**| ID of the target, e.g., a financial institution. (SCOPE: FI - optional) | [optional]
 **xPSUIPAddress** | **kotlin.String**| IP address of the user initiating the operation (SCOPE: FI - optional) | [optional]
 **xPSUUserAgent** | **kotlin.String**| User of the client software (SCOPE: FI - optional) | [optional]

### Return type

[**SinglePaymentsGet200Response**](SinglePaymentsGet200Response.md)

### Authorization


Configure OAuth2:
    ApiClient.accessToken = ""

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

<a name="singlePaymentsPost"></a>
# **singlePaymentsPost**
> singlePaymentsPost(authorization, xCorAPIClientID, xCorrelationID, userAgent, singlepaymentsSubmissionRequest, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Initiate new single payments submission

Create new single payments submission.

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = SinglePaymentsApi()
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val singlepaymentsSubmissionRequest : SinglepaymentsSubmissionRequest =  // SinglepaymentsSubmissionRequest | Details of single payments submission to be added.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    apiInstance.singlePaymentsPost(authorization, xCorAPIClientID, xCorrelationID, userAgent, singlepaymentsSubmissionRequest, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
} catch (e: ClientException) {
    println("4xx response calling SinglePaymentsApi#singlePaymentsPost")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling SinglePaymentsApi#singlePaymentsPost")
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
 **singlepaymentsSubmissionRequest** | [**SinglepaymentsSubmissionRequest**](SinglepaymentsSubmissionRequest.md)| Details of single payments submission to be added. |
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

<a name="singlePaymentsSubmissionIdDelete"></a>
# **singlePaymentsSubmissionIdDelete**
> singlePaymentsSubmissionIdDelete(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Delete a single payment

Delete single payment with corresponding submissionId.

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = SinglePaymentsApi()
val submissionID : kotlin.String = submissionId // kotlin.String | ID of payment submission to be retrieved.
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    apiInstance.singlePaymentsSubmissionIdDelete(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
} catch (e: ClientException) {
    println("4xx response calling SinglePaymentsApi#singlePaymentsSubmissionIdDelete")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling SinglePaymentsApi#singlePaymentsSubmissionIdDelete")
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

<a name="singlePaymentsSubmissionIdGet"></a>
# **singlePaymentsSubmissionIdGet**
> SinglepaymentsSubmissionRequest singlePaymentsSubmissionIdGet(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Get a specific payment

Receive payment with corresponding submissionId.

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = SinglePaymentsApi()
val submissionID : kotlin.String = submissionId // kotlin.String | ID of payment submission to be retrieved.
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    val result : SinglepaymentsSubmissionRequest = apiInstance.singlePaymentsSubmissionIdGet(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
    println(result)
} catch (e: ClientException) {
    println("4xx response calling SinglePaymentsApi#singlePaymentsSubmissionIdGet")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling SinglePaymentsApi#singlePaymentsSubmissionIdGet")
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

[**SinglepaymentsSubmissionRequest**](SinglepaymentsSubmissionRequest.md)

### Authorization


Configure OAuth2:
    ApiClient.accessToken = ""

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

<a name="singlePaymentsSubmissionIdStatusGet"></a>
# **singlePaymentsSubmissionIdStatusGet**
> PaymentSubmissionStatus singlePaymentsSubmissionIdStatusGet(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)

Get status information for the specific single payment

Retrieve a specific single payment submission&#39;s status.

### Example
```kotlin
// Import classes:
//import org.openapitools.client.infrastructure.*
//import org.openapitools.client.models.*

val apiInstance = SinglePaymentsApi()
val submissionID : kotlin.String = submissionId // kotlin.String | ID of payment submission to be retrieved.
val authorization : kotlin.String = authorization_example // kotlin.String | Bearer followed by a base64 encoded OAuth access token
val xCorAPIClientID : kotlin.String = xCorAPIClientID_example // kotlin.String | ID of the client forwarded to the provider. (SCOPE: FI)
val xCorrelationID : kotlin.String = xCorrelationID_example // kotlin.String | Unique ID (defined by the caller) which will be reflected back in the response.
val userAgent : kotlin.String = userAgent_example // kotlin.String | Name and version of the of the Client software.
val xCorAPITargetID : kotlin.String = xCorAPITargetID_example // kotlin.String | ID of the target, e.g., a financial institution. (SCOPE: FI - optional)
val xPSUIPAddress : kotlin.String = xPSUIPAddress_example // kotlin.String | IP address of the user initiating the operation (SCOPE: FI - optional)
val xPSUUserAgent : kotlin.String = xPSUUserAgent_example // kotlin.String | User of the client software (SCOPE: FI - optional)
try {
    val result : PaymentSubmissionStatus = apiInstance.singlePaymentsSubmissionIdStatusGet(submissionID, authorization, xCorAPIClientID, xCorrelationID, userAgent, xCorAPITargetID, xPSUIPAddress, xPSUUserAgent)
    println(result)
} catch (e: ClientException) {
    println("4xx response calling SinglePaymentsApi#singlePaymentsSubmissionIdStatusGet")
    e.printStackTrace()
} catch (e: ServerException) {
    println("5xx response calling SinglePaymentsApi#singlePaymentsSubmissionIdStatusGet")
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

