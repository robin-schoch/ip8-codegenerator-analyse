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

import org.openapitools.server.models.CommonErrorType

/**
 * 
 * @param type 
 * @param title 
 * @param detail 
 * @param instance 
 */
data class CommonErrorResponse(
    val type: CommonErrorType? = null,
    val title: kotlin.String? = null,
    val detail: kotlin.String? = null,
    val instance: kotlin.String? = null
) 

