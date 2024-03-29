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


import com.squareup.moshi.Json

/**
 * either remittanceReference or remittanceInformation must be set
 *
 * @param type 
 * @param reference 
 */


data class PaymentIsrRemittanceReference (

    @Json(name = "type")
    val type: PaymentIsrRemittanceReference.Type? = null,

    @Json(name = "reference")
    val reference: kotlin.String? = null

) {

    /**
     * 
     *
     * Values: iSR
     */
    enum class Type(val value: kotlin.String) {
        @Json(name = "ISR") iSR("ISR");
    }
}

