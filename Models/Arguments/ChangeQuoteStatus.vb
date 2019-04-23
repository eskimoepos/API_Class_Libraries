Imports System.ComponentModel.DataAnnotations

Public Class ChangeQuoteStatus
    Inherits EskimoBaseClass

    Implements IValidatableObject

    <Required>
    Property QuoteID As Integer

    <StringLength(3, ErrorMessage:="The StoreID must be 3 digits.", MinimumLength:=3)>
    <Required>
    Property StoreID As String

    <EnumDataType(GetType(clsQuote.QuoteStatusEnum))>
    <Required>
    Property NewStatus As clsQuote.QuoteStatusEnum

    Property ReplacementQuoteNum As Integer?
    Property TillNumber As Integer?
    Property ReceiptNumber As Integer?
    Property OperatorID As String
    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim lst As New List(Of ValidationResult)

        If NewStatus = clsQuote.QuoteStatusEnum.Replaced AndAlso Me.ReplacementQuoteNum Is Nothing Then
            lst.Add(New ValidationResult("The replacement Quote number must be supplied when setting the New Status to Replaced."))
        End If

        If NewStatus <> clsQuote.QuoteStatusEnum.Replaced AndAlso Me.ReplacementQuoteNum IsNot Nothing Then
            lst.Add(New ValidationResult("The replacement Quote number should not be passed unless setting the New Status to Replaced."))
        End If

        If NewStatus = clsQuote.QuoteStatusEnum.SuccessfullyConverted AndAlso Me.TillNumber Is Nothing Then
            lst.Add(New ValidationResult("The Till Number must be supplied when setting the New Status to SuccessfullyConverted."))
        End If

        If NewStatus <> clsQuote.QuoteStatusEnum.SuccessfullyConverted AndAlso Me.TillNumber IsNot Nothing Then
            lst.Add(New ValidationResult("The Till Number should not be passed unless setting the New Status to SuccessfullyConverted."))
        End If

        If NewStatus = clsQuote.QuoteStatusEnum.SuccessfullyConverted AndAlso Me.ReceiptNumber Is Nothing Then
            lst.Add(New ValidationResult("The Receipt Number must be supplied when setting the New Status to SuccessfullyConverted."))
        End If

        If NewStatus <> clsQuote.QuoteStatusEnum.SuccessfullyConverted AndAlso Me.ReceiptNumber IsNot Nothing Then
            lst.Add(New ValidationResult("The Receipt Number should not be passed unless setting the New Status to SuccessfullyConverted."))
        End If

        Return lst
    End Function
End Class
