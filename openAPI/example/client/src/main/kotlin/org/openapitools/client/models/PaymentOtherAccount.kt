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
 * 
 *
 * @param type The allowed account identification type for the creditor account depends on the payment type. The debtor account must always be an IBAN.
 * @param identification 
 */


data class PaymentOtherAccount (

    /* The allowed account identification type for the creditor account depends on the payment type. The debtor account must always be an IBAN. */
    @Json(name = "type")
    val type: PaymentOtherAccount.Type,

    @Json(name = "identification")
    val identification: kotlin.String

) {

    /**
     * The allowed account identification type for the creditor account depends on the payment type. The debtor account must always be an IBAN.
     *
     * Values: oTHER
     */
    enum class Type(val value: kotlin.String) {
        @Json(name = "OTHER") oTHER("OTHER");
    }
}

