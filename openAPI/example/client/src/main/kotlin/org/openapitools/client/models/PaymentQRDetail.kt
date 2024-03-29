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

import org.openapitools.client.models.PaymentCreditor
import org.openapitools.client.models.PaymentDebtor
import org.openapitools.client.models.PaymentIbanRemittanceReference
import org.openapitools.client.models.PaymentQrIbanAccount

import com.squareup.moshi.Json

/**
 * 
 *
 * @param creditorAccount 
 * @param creditor 
 * @param ultimateCreditor 
 * @param ultimateDebtor 
 * @param remittanceReference 
 * @param remittanceInformation either remittanceReference or remittanceInformation must be set
 */


data class PaymentQRDetail (

    @Json(name = "creditorAccount")
    val creditorAccount: PaymentQrIbanAccount,

    @Json(name = "creditor")
    val creditor: PaymentCreditor,

    @Json(name = "ultimateCreditor")
    val ultimateCreditor: PaymentCreditor? = null,

    @Json(name = "ultimateDebtor")
    val ultimateDebtor: PaymentDebtor? = null,

    @Json(name = "remittanceReference")
    val remittanceReference: PaymentIbanRemittanceReference? = null,

    /* either remittanceReference or remittanceInformation must be set */
    @Json(name = "remittanceInformation")
    val remittanceInformation: kotlin.String? = null

)

