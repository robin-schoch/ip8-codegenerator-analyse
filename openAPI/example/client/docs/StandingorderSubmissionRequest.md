
# StandingorderSubmissionRequest

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**messageId** | **kotlin.String** |  | 
**initiatingPartyId** | **kotlin.String** |  | 
**debtorAccount** | [**PaymentIbanAccount**](PaymentIbanAccount.md) |  | 
**instructionId** | **kotlin.String** |  | 
**endToEndId** | **kotlin.String** |  | 
**instructedAmount** | [**PaymentCurrencyAmount**](PaymentCurrencyAmount.md) |  | 
**startDate** | [**java.time.LocalDate**](java.time.LocalDate.md) | The first applicable day of execution starting from this date is the first payment.  | 
**frequency** | [**FrequencyCode**](FrequencyCode.md) |  | 
**requestedExecutionDate** | [**java.time.LocalDate**](java.time.LocalDate.md) |  |  [optional]
**ibanDetails** | [**PaymentIBANDetail**](PaymentIBANDetail.md) |  |  [optional]
**isrDetails** | [**PaymentISRDetail**](PaymentISRDetail.md) |  |  [optional]
**otherDetails** | [**PaymentOtherDetail**](PaymentOtherDetail.md) |  |  [optional]
**qrDetails** | [**PaymentQRDetail**](PaymentQRDetail.md) |  |  [optional]
**endDate** | [**java.time.LocalDate**](java.time.LocalDate.md) | The last applicable day of execution. If not given, it is an infinite standing order. |  [optional]
**executionRule** | [**ExecutionRule**](ExecutionRule.md) |  |  [optional]
**dayOfExecution** | [**DayOfExecution**](DayOfExecution.md) |  |  [optional]
**executionMode** | [**inline**](#ExecutionMode) | The code of execution mode defines when or how standing order will be cancelled, processed the last time.   * UNTIL_DATE - standing order is valid until specific date - field endDate.  * UNTIL_CANCELLATION - standing order is valid forever and must be cancelled by client.  |  [optional]
**executionBreaks** | [**kotlin.collections.List&lt;StandingorderSubmissionRequestExecutionBreaksInner&gt;**](StandingorderSubmissionRequestExecutionBreaksInner.md) | List of break periods. |  [optional]


<a name="ExecutionMode"></a>
## Enum: executionMode
Name | Value
---- | -----
executionMode | UNTIL_DATE, UNTIL_CANCELLATION



