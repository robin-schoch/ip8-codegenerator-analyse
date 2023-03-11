
# SinglepaymentsSubmissionRequest

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**messageId** | **kotlin.String** |  | 
**initiatingPartyId** | **kotlin.String** |  | 
**debtorAccount** | [**PaymentIbanAccount**](PaymentIbanAccount.md) |  | 
**instructionId** | **kotlin.String** |  | 
**endToEndId** | **kotlin.String** |  | 
**instructedAmount** | [**PaymentCurrencyAmount**](PaymentCurrencyAmount.md) |  | 
**requestedExecutionDate** | [**java.time.LocalDate**](java.time.LocalDate.md) |  |  [optional]
**ibanDetails** | [**PaymentIBANDetail**](PaymentIBANDetail.md) |  |  [optional]
**isrDetails** | [**PaymentISRDetail**](PaymentISRDetail.md) |  |  [optional]
**otherDetails** | [**PaymentOtherDetail**](PaymentOtherDetail.md) |  |  [optional]
**qrDetails** | [**PaymentQRDetail**](PaymentQRDetail.md) |  |  [optional]



