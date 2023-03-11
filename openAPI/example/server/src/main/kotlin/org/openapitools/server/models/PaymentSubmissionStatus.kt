/**
* Common Payment API
* This specification defines a simple payment API for payment types used in Switzerland.  The API is supposed to be used by customers who want to initiate a payment at their bank.  Note that, consents and SCA will be handled in a dedicated specification file. This specification uses schema definitions from the Common Data Model v1.2.1. 
*
* The version of the OpenAPI document: 1.3.0
* Contact: info@common-api.ch
*
* NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
* https://openapi-generator.tech
* Do not edit the class manually.
*/
package org.openapitools.server.models

import org.openapitools.server.models.PaymentInstructionItemStatus

/**
 * 
 * @param statusCode 
 * @param messageId 
 * @param transactions 
 */
data class PaymentSubmissionStatus(
    val statusCode: PaymentSubmissionStatus.StatusCode,
    val messageId: kotlin.String? = null,
    val transactions: kotlin.collections.List<PaymentInstructionItemStatus>? = null
) 
{
    /**
    * 
    * Values: aCCP,rJCT,pART
    */
    enum class StatusCode(val value: kotlin.String){
        aCCP("ACCP"),
        rJCT("RJCT"),
        pART("PART");
    }
}

