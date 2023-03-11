/**
 *
 * Please note:
 * This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * Do not edit this file manually.
 *
 */

@file:Suppress(
    "ArrayInDataClass",
    "EnumEntryName",
    "RemoveRedundantQualifierName",
    "UnusedImport"
)

package org.openapitools.client.models

import org.openapitools.client.models.PaymentStructuredAddress
import org.openapitools.client.models.PaymentUnstructuredAddress

import com.squareup.moshi.Json

/**
 * Either structured or unstructured must be set
 *
 * @param structured 
 * @param unstructured 
 */


data class PaymentStructuredOrUnstructuredAddress (

    @Json(name = "structured")
    val structured: PaymentStructuredAddress? = null,

    @Json(name = "unstructured")
    val unstructured: PaymentUnstructuredAddress? = null

)

