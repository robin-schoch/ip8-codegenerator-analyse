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
 * Error Types for commonErrorResponse.
 *
 * Values: iNVALIDPAYLOAD,mALFORMEDPAYLOAD,iNVALIDTOKEN,eXPIREDTOKEN,iNSUFFICIENTPRIVILEGES,nOACCESSTORESOURCE,rESOURCEDOESNOTEXIST,rESOURCENOTREADY,rESOURCETOOLARGE,wRONGMETHOD,oPERATIONNOTALLOWED,tECHNICALERROR,nOTIMPLEMENTED,sERVICEUNAVAILABLE
 */

enum class CommonErrorType(val value: kotlin.String) {

    @Json(name = "/problems/INVALID_PAYLOAD")
    iNVALIDPAYLOAD("/problems/INVALID_PAYLOAD"),

    // ...
    @Json(name = "/problems/SERVICE_UNAVAILABLE")
    sERVICEUNAVAILABLE("/problems/SERVICE_UNAVAILABLE");

    override fun toString(): String = value

    companion object {

        // ...
    }
}