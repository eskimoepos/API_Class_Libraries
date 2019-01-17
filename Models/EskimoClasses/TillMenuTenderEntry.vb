Imports System.ComponentModel.DataAnnotations

Public Class clsTenderEntry

    Inherits EskimoBaseClass
    Implements IValidatableObject

    Enum TenderTypeEnum
        Standard = 1
        PayByCard = 2
    End Enum

    ''' <summary>
    ''' Must match a valid Eskimo Tender ID
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property TenderID As Integer

    ''' <summary>
    ''' The amount tendered i.e. 10.5 for £10.50 or €10.50
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property Amount As Decimal

    ''' <summary>
    ''' i.e. Mastercard/Visa Debit etc. Only supply when TenderType is CreditCard
    ''' </summary>
    ''' <returns></returns>
    Property CardSupplier As String

    <EnumDataType(GetType(TenderTypeEnum))>
    <Required>
    Property TenderType As TenderTypeEnum

    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim lst As New List(Of ValidationResult)

        If Me.TenderType = TenderTypeEnum.PayByCard AndAlso Me.CardSupplier Is Nothing Then
            lst.Add(New ValidationResult("Credit Card Supplier not supplied."))
        End If

        If Me.TenderType <> TenderTypeEnum.PayByCard AndAlso Me.CardSupplier IsNot Nothing Then
            lst.Add(New ValidationResult("No need to supply Credit Card Supplier when not a credit card tender type."))
        End If

        If Me.CardToken IsNot Nothing AndAlso Me.CardToken.Length > 0 AndAlso TenderID <> -4 Then
            lst.Add(New ValidationResult($"The token has been supplied against a TenderID of {Me.TenderID} rather than -4"))
        End If

        If Me.CardToken Is Nothing AndAlso TenderID = -4 Then
            lst.Add(New ValidationResult($"CardToken value not supplied with mail order token tender entry."))
        End If

        Return lst

    End Function

    ''' <summary>
    ''' Optional. The Transaction Identifier. For example PayPal's ID for the payment. Can be used later for refunding.
    ''' </summary>
    ''' <returns></returns>
    <MaxLength(100)>
    Property PaymentReference As String

    ''' <summary>
    ''' An optional field used for tokenisation. Stores that token that represent the card used.
    ''' </summary>
    ''' <returns></returns>
    Property CardToken As String

End Class
