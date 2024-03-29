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

import org.openapitools.server.models.DayOfExecution
import org.openapitools.server.models.ExecutionRule
import org.openapitools.server.models.FrequencyCode
import org.openapitools.server.models.PaymentCurrencyAmount
import org.openapitools.server.models.PaymentIBANDetail
import org.openapitools.server.models.PaymentISRDetail
import org.openapitools.server.models.PaymentIbanAccount
import org.openapitools.server.models.PaymentOtherDetail
import org.openapitools.server.models.PaymentQRDetail
import org.openapitools.server.models.StandingorderSubmissionRequestExecutionBreaksInner

/**
 * 
 * @param messageId 
 * @param initiatingPartyId 
 * @param debtorAccount 
 * @param instructionId 
 * @param endToEndId 
 * @param instructedAmount 
 * @param startDate The first applicable day of execution starting from this date is the first payment. 
 * @param frequency 
 * @param requestedExecutionDate 
 * @param ibanDetails 
 * @param isrDetails 
 * @param otherDetails 
 * @param qrDetails 
 * @param endDate The last applicable day of execution. If not given, it is an infinite standing order.
 * @param executionRule 
 * @param dayOfExecution 
 * @param executionMode The code of execution mode defines when or how standing order will be cancelled, processed the last time.   * UNTIL_DATE - standing order is valid until specific date - field endDate.  * UNTIL_CANCELLATION - standing order is valid forever and must be cancelled by client. 
 * @param executionBreaks List of break periods.
 */
data class StandingorderSubmissionRequest(
    val messageId: kotlin.String,
    val initiatingPartyId: kotlin.String,
    val debtorAccount: PaymentIbanAccount,
    val instructionId: kotlin.String,
    val endToEndId: kotlin.String,
    val instructedAmount: PaymentCurrencyAmount,
    /* The first applicable day of execution starting from this date is the first payment.  */
    val startDate: java.time.LocalDate,
    val frequency: FrequencyCode,
    val requestedExecutionDate: java.time.LocalDate? = null,
    val ibanDetails: PaymentIBANDetail? = null,
    val isrDetails: PaymentISRDetail? = null,
    val otherDetails: PaymentOtherDetail? = null,
    val qrDetails: PaymentQRDetail? = null,
    /* The last applicable day of execution. If not given, it is an infinite standing order. */
    val endDate: java.time.LocalDate? = null,
    val executionRule: ExecutionRule? = null,
    val dayOfExecution: DayOfExecution? = null,
    /* The code of execution mode defines when or how standing order will be cancelled, processed the last time.   * UNTIL_DATE - standing order is valid until specific date - field endDate.  * UNTIL_CANCELLATION - standing order is valid forever and must be cancelled by client.  */
    val executionMode: StandingorderSubmissionRequest.ExecutionMode? = null,
    /* List of break periods. */
    val executionBreaks: kotlin.collections.List<StandingorderSubmissionRequestExecutionBreaksInner>? = null
) 
{
    /**
    * The code of execution mode defines when or how standing order will be cancelled, processed the last time.   * UNTIL_DATE - standing order is valid until specific date - field endDate.  * UNTIL_CANCELLATION - standing order is valid forever and must be cancelled by client. 
    * Values: dATE,cANCELLATION
    */
    enum class ExecutionMode(val value: kotlin.String){
        dATE("UNTIL_DATE"),
        cANCELLATION("UNTIL_CANCELLATION");
    }
}

