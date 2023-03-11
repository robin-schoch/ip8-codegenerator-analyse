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


/**
 * Error Types for commonErrorResponse.
 * Values: iNVALIDPAYLOAD,mALFORMEDPAYLOAD,iNVALIDTOKEN,eXPIREDTOKEN,iNSUFFICIENTPRIVILEGES,nOACCESSTORESOURCE,rESOURCEDOESNOTEXIST,rESOURCENOTREADY,rESOURCETOOLARGE,wRONGMETHOD,oPERATIONNOTALLOWED,tECHNICALERROR,nOTIMPLEMENTED,sERVICEUNAVAILABLE
 */
enum class CommonErrorType(val value: kotlin.String) {

    iNVALIDPAYLOAD("/problems/INVALID_PAYLOAD"),

    mALFORMEDPAYLOAD("/problems/MALFORMED_PAYLOAD"),

    iNVALIDTOKEN("/problems/INVALID_TOKEN"),

    eXPIREDTOKEN("/problems/EXPIRED_TOKEN"),

    iNSUFFICIENTPRIVILEGES("/problems/INSUFFICIENT_PRIVILEGES"),

    nOACCESSTORESOURCE("/problems/NO_ACCESS_TO_RESOURCE"),

    rESOURCEDOESNOTEXIST("/problems/RESOURCE_DOES_NOT_EXIST"),

    RESOURCENOTREADY("/problems/RESOURCE_NOT_READY"),

    rESOURCETOOLARGE("/problems/RESOURCE_TOO_LARGE"),

    wRONGMETHOD("/problems/WRONG_METHOD"),

    oPERATIONNOTALLOWED("/problems/OPERATION_NOT_ALLOWED"),

    tECHNICALERROR("/problems/TECHNICAL_ERROR"),

    nOTIMPLEMENTED("/problems/NOT_IMPLEMENTED"),

    sERVICEUNAVAILABLE("/problems/SERVICE_UNAVAILABLE");

}
