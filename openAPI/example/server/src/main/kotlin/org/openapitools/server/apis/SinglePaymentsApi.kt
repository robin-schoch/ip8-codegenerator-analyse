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
package org.openapitools.server.apis

import com.google.gson.Gson
import io.ktor.application.*
import io.ktor.auth.*
import io.ktor.http.*
import io.ktor.response.*
import org.openapitools.server.Paths
import io.ktor.locations.*
import io.ktor.routing.*
import org.openapitools.server.infrastructure.ApiPrincipal
import org.openapitools.server.models.CommonErrorResponse
import org.openapitools.server.models.PaymentSubmissionStatus
import org.openapitools.server.models.SinglePaymentsGet200Response
import org.openapitools.server.models.SinglepaymentsSubmissionRequest

@KtorExperimentalLocationsAPI
fun Route.SinglePaymentsApi() {
    val gson = Gson()
    val empty = mutableMapOf<String, Any?>()

    authenticate("OAuth2") {
    get<Paths.singlePaymentsGet> {
        val principal = call.authentication.principal<OAuthAccessTokenResponse>()!!
        
        val exampleContentType = "application/json"
            val exampleContentString = """{
              "_links" : {
                "next" : "next",
                "previous" : "previous",
                "last" : "last",
                "self" : "self",
                "first" : "first"
              },
              "paymentList" : [ {
                "initiatingPartyId" : "TPP01746",
                "debtorAccount" : {
                  "identification" : "CH9300762011623852957",
                  "type" : "IBAN"
                },
                "requestedExecutionDate" : "2018-04-07T00:00:00.000+00:00",
                "otherDetails" : {
                  "chargeBearer" : "SHAR",
                  "creditorAgent" : {
                    "clearingSystemMemberIdentification" : {
                      "code" : "CHBCC",
                      "memberId" : "152"
                    },
                    "bic" : "BDEMMXMM"
                  },
                  "creditorAccount" : {
                    "identification" : "01-39139-1",
                    "type" : "OTHER"
                  },
                  "creditor" : {
                    "postalAddress" : {
                      "unstructured" : {
                        "country" : "CH",
                        "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                      },
                      "structured" : {
                        "country" : "CH",
                        "streetName" : "Rue de la gare",
                        "townName" : "Biel",
                        "buildingNumber" : "24",
                        "postCode" : "2501"
                      }
                    },
                    "name" : "name"
                  },
                  "remittanceReference" : {
                    "reference" : "210000000003139471430009017",
                    "type" : "SCOR"
                  }
                },
                "ibanDetails" : {
                  "chargeBearer" : "SHAR",
                  "creditorAgent" : {
                    "clearingSystemMemberIdentification" : {
                      "code" : "CHBCC",
                      "memberId" : "152"
                    },
                    "bic" : "BDEMMXMM"
                  },
                  "remittanceInformation" : "Rechnung Nr. 408",
                  "creditorAccount" : {
                    "identification" : "CH9300762011623852957",
                    "type" : "IBAN"
                  },
                  "sepaIndicator" : true,
                  "creditor" : {
                    "postalAddress" : {
                      "unstructured" : {
                        "country" : "CH",
                        "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                      },
                      "structured" : {
                        "country" : "CH",
                        "streetName" : "Rue de la gare",
                        "townName" : "Biel",
                        "buildingNumber" : "24",
                        "postCode" : "2501"
                      }
                    },
                    "name" : "name"
                  },
                  "remittanceReference" : {
                    "reference" : "210000000003139471430009017",
                    "type" : "SCOR"
                  }
                },
                "messageId" : "eb6305c91f7f49deaed016487c27b42d",
                "instructionId" : "INSTR-001",
                "instructedAmount" : {
                  "amount" : "10.25",
                  "currency" : "CHF"
                },
                "endToEndId" : "ENDTOENDID-001",
                "qrDetails" : {
                  "remittanceInformation" : "Rechnung Nr. 408",
                  "ultimateCreditor" : {
                    "postalAddress" : {
                      "unstructured" : {
                        "country" : "CH",
                        "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                      },
                      "structured" : {
                        "country" : "CH",
                        "streetName" : "Rue de la gare",
                        "townName" : "Biel",
                        "buildingNumber" : "24",
                        "postCode" : "2501"
                      }
                    },
                    "name" : "name"
                  },
                  "creditorAccount" : {
                    "identification" : "CH9300762011623852957",
                    "type" : "IBAN"
                  },
                  "creditor" : {
                    "postalAddress" : {
                      "unstructured" : {
                        "country" : "CH",
                        "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                      },
                      "structured" : {
                        "country" : "CH",
                        "streetName" : "Rue de la gare",
                        "townName" : "Biel",
                        "buildingNumber" : "24",
                        "postCode" : "2501"
                      }
                    },
                    "name" : "name"
                  },
                  "remittanceReference" : {
                    "reference" : "210000000003139471430009017",
                    "type" : "SCOR"
                  },
                  "ultimateDebtor" : {
                    "postalAddress" : {
                      "unstructured" : {
                        "country" : "CH",
                        "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                      },
                      "structured" : {
                        "country" : "CH",
                        "streetName" : "Rue de la gare",
                        "townName" : "Biel",
                        "buildingNumber" : "24",
                        "postCode" : "2501"
                      }
                    },
                    "name" : "Hans Muster"
                  }
                },
                "isrDetails" : {
                  "creditorAccount" : {
                    "identification" : "01-39139-1",
                    "type" : "OTHER"
                  },
                  "creditor" : {
                    "postalAddress" : {
                      "unstructured" : {
                        "country" : "CH",
                        "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                      },
                      "structured" : {
                        "country" : "CH",
                        "streetName" : "Rue de la gare",
                        "townName" : "Biel",
                        "buildingNumber" : "24",
                        "postCode" : "2501"
                      }
                    },
                    "name" : "name"
                  },
                  "remittanceReference" : {
                    "reference" : "210000000003139471430009017",
                    "type" : "ISR"
                  }
                }
              }, {
                "initiatingPartyId" : "TPP01746",
                "debtorAccount" : {
                  "identification" : "CH9300762011623852957",
                  "type" : "IBAN"
                },
                "requestedExecutionDate" : "2018-04-07T00:00:00.000+00:00",
                "otherDetails" : {
                  "chargeBearer" : "SHAR",
                  "creditorAgent" : {
                    "clearingSystemMemberIdentification" : {
                      "code" : "CHBCC",
                      "memberId" : "152"
                    },
                    "bic" : "BDEMMXMM"
                  },
                  "creditorAccount" : {
                    "identification" : "01-39139-1",
                    "type" : "OTHER"
                  },
                  "creditor" : {
                    "postalAddress" : {
                      "unstructured" : {
                        "country" : "CH",
                        "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                      },
                      "structured" : {
                        "country" : "CH",
                        "streetName" : "Rue de la gare",
                        "townName" : "Biel",
                        "buildingNumber" : "24",
                        "postCode" : "2501"
                      }
                    },
                    "name" : "name"
                  },
                  "remittanceReference" : {
                    "reference" : "210000000003139471430009017",
                    "type" : "SCOR"
                  }
                },
                "ibanDetails" : {
                  "chargeBearer" : "SHAR",
                  "creditorAgent" : {
                    "clearingSystemMemberIdentification" : {
                      "code" : "CHBCC",
                      "memberId" : "152"
                    },
                    "bic" : "BDEMMXMM"
                  },
                  "remittanceInformation" : "Rechnung Nr. 408",
                  "creditorAccount" : {
                    "identification" : "CH9300762011623852957",
                    "type" : "IBAN"
                  },
                  "sepaIndicator" : true,
                  "creditor" : {
                    "postalAddress" : {
                      "unstructured" : {
                        "country" : "CH",
                        "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                      },
                      "structured" : {
                        "country" : "CH",
                        "streetName" : "Rue de la gare",
                        "townName" : "Biel",
                        "buildingNumber" : "24",
                        "postCode" : "2501"
                      }
                    },
                    "name" : "name"
                  },
                  "remittanceReference" : {
                    "reference" : "210000000003139471430009017",
                    "type" : "SCOR"
                  }
                },
                "messageId" : "eb6305c91f7f49deaed016487c27b42d",
                "instructionId" : "INSTR-001",
                "instructedAmount" : {
                  "amount" : "10.25",
                  "currency" : "CHF"
                },
                "endToEndId" : "ENDTOENDID-001",
                "qrDetails" : {
                  "remittanceInformation" : "Rechnung Nr. 408",
                  "ultimateCreditor" : {
                    "postalAddress" : {
                      "unstructured" : {
                        "country" : "CH",
                        "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                      },
                      "structured" : {
                        "country" : "CH",
                        "streetName" : "Rue de la gare",
                        "townName" : "Biel",
                        "buildingNumber" : "24",
                        "postCode" : "2501"
                      }
                    },
                    "name" : "name"
                  },
                  "creditorAccount" : {
                    "identification" : "CH9300762011623852957",
                    "type" : "IBAN"
                  },
                  "creditor" : {
                    "postalAddress" : {
                      "unstructured" : {
                        "country" : "CH",
                        "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                      },
                      "structured" : {
                        "country" : "CH",
                        "streetName" : "Rue de la gare",
                        "townName" : "Biel",
                        "buildingNumber" : "24",
                        "postCode" : "2501"
                      }
                    },
                    "name" : "name"
                  },
                  "remittanceReference" : {
                    "reference" : "210000000003139471430009017",
                    "type" : "SCOR"
                  },
                  "ultimateDebtor" : {
                    "postalAddress" : {
                      "unstructured" : {
                        "country" : "CH",
                        "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                      },
                      "structured" : {
                        "country" : "CH",
                        "streetName" : "Rue de la gare",
                        "townName" : "Biel",
                        "buildingNumber" : "24",
                        "postCode" : "2501"
                      }
                    },
                    "name" : "Hans Muster"
                  }
                },
                "isrDetails" : {
                  "creditorAccount" : {
                    "identification" : "01-39139-1",
                    "type" : "OTHER"
                  },
                  "creditor" : {
                    "postalAddress" : {
                      "unstructured" : {
                        "country" : "CH",
                        "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                      },
                      "structured" : {
                        "country" : "CH",
                        "streetName" : "Rue de la gare",
                        "townName" : "Biel",
                        "buildingNumber" : "24",
                        "postCode" : "2501"
                      }
                    },
                    "name" : "name"
                  },
                  "remittanceReference" : {
                    "reference" : "210000000003139471430009017",
                    "type" : "ISR"
                  }
                }
              } ]
            }"""
            
            when (exampleContentType) {
                "application/json" -> call.respond(gson.fromJson(exampleContentString, empty::class.java))
                "application/xml" -> call.respondText(exampleContentString, ContentType.Text.Xml)
                else -> call.respondText(exampleContentString)
            }
    }
    }

    authenticate("OAuth2") {
    post<Paths.singlePaymentsPost> {
        val principal = call.authentication.principal<OAuthAccessTokenResponse>()!!
        
        call.respond(HttpStatusCode.NotImplemented)
    }
    }

    authenticate("OAuth2") {
    delete<Paths.singlePaymentsSubmissionIdDelete> {
        val principal = call.authentication.principal<OAuthAccessTokenResponse>()!!
        
        call.respond(HttpStatusCode.NotImplemented)
    }
    }

    authenticate("OAuth2") {
    get<Paths.singlePaymentsSubmissionIdGet> {
        val principal = call.authentication.principal<OAuthAccessTokenResponse>()!!
        
        val exampleContentType = "application/json"
            val exampleContentString = """{
              "initiatingPartyId" : "TPP01746",
              "debtorAccount" : {
                "identification" : "CH9300762011623852957",
                "type" : "IBAN"
              },
              "requestedExecutionDate" : "2018-04-07T00:00:00.000+00:00",
              "otherDetails" : {
                "chargeBearer" : "SHAR",
                "creditorAgent" : {
                  "clearingSystemMemberIdentification" : {
                    "code" : "CHBCC",
                    "memberId" : "152"
                  },
                  "bic" : "BDEMMXMM"
                },
                "creditorAccount" : {
                  "identification" : "01-39139-1",
                  "type" : "OTHER"
                },
                "creditor" : {
                  "postalAddress" : {
                    "unstructured" : {
                      "country" : "CH",
                      "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                    },
                    "structured" : {
                      "country" : "CH",
                      "streetName" : "Rue de la gare",
                      "townName" : "Biel",
                      "buildingNumber" : "24",
                      "postCode" : "2501"
                    }
                  },
                  "name" : "name"
                },
                "remittanceReference" : {
                  "reference" : "210000000003139471430009017",
                  "type" : "SCOR"
                }
              },
              "ibanDetails" : {
                "chargeBearer" : "SHAR",
                "creditorAgent" : {
                  "clearingSystemMemberIdentification" : {
                    "code" : "CHBCC",
                    "memberId" : "152"
                  },
                  "bic" : "BDEMMXMM"
                },
                "remittanceInformation" : "Rechnung Nr. 408",
                "creditorAccount" : {
                  "identification" : "CH9300762011623852957",
                  "type" : "IBAN"
                },
                "sepaIndicator" : true,
                "creditor" : {
                  "postalAddress" : {
                    "unstructured" : {
                      "country" : "CH",
                      "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                    },
                    "structured" : {
                      "country" : "CH",
                      "streetName" : "Rue de la gare",
                      "townName" : "Biel",
                      "buildingNumber" : "24",
                      "postCode" : "2501"
                    }
                  },
                  "name" : "name"
                },
                "remittanceReference" : {
                  "reference" : "210000000003139471430009017",
                  "type" : "SCOR"
                }
              },
              "messageId" : "eb6305c91f7f49deaed016487c27b42d",
              "instructionId" : "INSTR-001",
              "instructedAmount" : {
                "amount" : "10.25",
                "currency" : "CHF"
              },
              "endToEndId" : "ENDTOENDID-001",
              "qrDetails" : {
                "remittanceInformation" : "Rechnung Nr. 408",
                "ultimateCreditor" : {
                  "postalAddress" : {
                    "unstructured" : {
                      "country" : "CH",
                      "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                    },
                    "structured" : {
                      "country" : "CH",
                      "streetName" : "Rue de la gare",
                      "townName" : "Biel",
                      "buildingNumber" : "24",
                      "postCode" : "2501"
                    }
                  },
                  "name" : "name"
                },
                "creditorAccount" : {
                  "identification" : "CH9300762011623852957",
                  "type" : "IBAN"
                },
                "creditor" : {
                  "postalAddress" : {
                    "unstructured" : {
                      "country" : "CH",
                      "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                    },
                    "structured" : {
                      "country" : "CH",
                      "streetName" : "Rue de la gare",
                      "townName" : "Biel",
                      "buildingNumber" : "24",
                      "postCode" : "2501"
                    }
                  },
                  "name" : "name"
                },
                "remittanceReference" : {
                  "reference" : "210000000003139471430009017",
                  "type" : "SCOR"
                },
                "ultimateDebtor" : {
                  "postalAddress" : {
                    "unstructured" : {
                      "country" : "CH",
                      "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                    },
                    "structured" : {
                      "country" : "CH",
                      "streetName" : "Rue de la gare",
                      "townName" : "Biel",
                      "buildingNumber" : "24",
                      "postCode" : "2501"
                    }
                  },
                  "name" : "Hans Muster"
                }
              },
              "isrDetails" : {
                "creditorAccount" : {
                  "identification" : "01-39139-1",
                  "type" : "OTHER"
                },
                "creditor" : {
                  "postalAddress" : {
                    "unstructured" : {
                      "country" : "CH",
                      "addressLines" : [ "Robert Schneider SA", "Rue de la gare 24" ]
                    },
                    "structured" : {
                      "country" : "CH",
                      "streetName" : "Rue de la gare",
                      "townName" : "Biel",
                      "buildingNumber" : "24",
                      "postCode" : "2501"
                    }
                  },
                  "name" : "name"
                },
                "remittanceReference" : {
                  "reference" : "210000000003139471430009017",
                  "type" : "ISR"
                }
              }
            }"""
            
            when (exampleContentType) {
                "application/json" -> call.respond(gson.fromJson(exampleContentString, empty::class.java))
                "application/xml" -> call.respondText(exampleContentString, ContentType.Text.Xml)
                else -> call.respondText(exampleContentString)
            }
    }
    }

    authenticate("OAuth2") {
    get<Paths.singlePaymentsSubmissionIdStatusGet> {
        val principal = call.authentication.principal<OAuthAccessTokenResponse>()!!
        
        val exampleContentType = "application/json"
            val exampleContentString = """{
              "messageId" : "eb6305c91f7f49deaed016487c27b42d",
              "transactions" : [ {
                "reasonInformation" : "currency USD not allowed for payment type IBAN",
                "instructionId" : "DNCS-20180322-IXN0-TXN0",
                "reasonCode" : "CURR",
                "statusCode" : "RJCT"
              }, {
                "reasonInformation" : "currency USD not allowed for payment type IBAN",
                "instructionId" : "DNCS-20180322-IXN0-TXN0",
                "reasonCode" : "CURR",
                "statusCode" : "RJCT"
              } ],
              "statusCode" : "PART"
            }"""
            
            when (exampleContentType) {
                "application/json" -> call.respond(gson.fromJson(exampleContentString, empty::class.java))
                "application/xml" -> call.respondText(exampleContentString, ContentType.Text.Xml)
                else -> call.respondText(exampleContentString)
            }
    }
    }

}
