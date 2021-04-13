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
    ''' The date/time the money was taken (sometimes after that of the Sales date)
    ''' </summary>
    ''' <returns></returns>
    Property PaidDate As Date

    <EnumDataType(GetType(TenderTypeEnum))>
    <Required>
    Property TenderType As TenderTypeEnum

    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim lst As New List(Of ValidationResult)

        Select Case Me.TenderType
            Case TenderTypeEnum.PayByCard
                If Me.BankCardDetails Is Nothing Then
                    lst.Add(New ValidationResult("BankCardDetails not supplied."))
                End If
            Case Else
                'If Me.BankCardDetails IsNot Nothing Then
                '    lst.Add(New ValidationResult("No need to supply BankCardDetails when not a credit card tender type."))
                'End If
        End Select

        If Me.CardToken IsNot Nothing AndAlso Me.CardToken.Length > 0 AndAlso TenderID <> -4 Then
            lst.Add(New ValidationResult($"The token has been supplied against a TenderID of {Me.TenderID} rather than -4"))
        End If

        If Me.CardToken Is Nothing AndAlso TenderID = -4 Then
            lst.Add(New ValidationResult($"CardToken value not supplied with mail order token tender entry."))
        End If

        If Me.GiftCardDetails Is Nothing AndAlso TenderID = -6 Then
            lst.Add(New ValidationResult($"GiftCardDetails property not supplied with tender entry."))
        End If

        If Me.GiftCardDetails IsNot Nothing AndAlso TenderID <> -6 Then
            lst.Add(New ValidationResult($"The GiftCardDetails has been supplied against a TenderID of {Me.TenderID} rather than -6"))
        End If

        Return lst

    End Function

    ''' <summary>
    ''' Optional. The Transaction Identifier. For example PayPal's ID for the payment. Can be used later for refunding.
    ''' </summary>
    ''' <returns></returns>
    <MaxLength(100)>
    Property PaymentReference As String
    Property GiftCardDetails As clsGiftCardTenderDetails
    Property BankCardDetails As clsBankCardDetails

    ''' <summary>
    ''' An optional field used for tokenisation. Stores that token that represent the card used.
    ''' </summary>
    ''' <returns></returns>
    Property CardToken As String

End Class

Public Class clsBankCardDetails

    ''' <summary>
    ''' Optional field to store the Auth Code of the transaction as returned by the provider.
    ''' </summary>
    ''' <returns></returns>
    Property AuthCode As String

    ''' <summary>
    ''' i.e. Mastercard/Visa Debit etc. Only supply when TenderType is CreditCard
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property CardSupplier As String

    ''' <summary>
    ''' Optional. Card PAN (number) field which has masked charcters to obscure some of the digits. Sometimes this is, for example, in the format ************0119, other times it is 476173XXXXXX0119
    ''' </summary>
    ''' <returns></returns>
    Property MaskedPAN As String

End Class

Public Class clsGiftCardTenderDetails

    Inherits clsGiftCardBase

End Class

Public Class clsGiftCardBase

    ''' <summary>
    ''' The full card number scanned in
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property CardNumber As String

    ''' <summary>
    ''' A cut down form of the card number containing some, but not all of the digits. Returned by the Gift Card service provider.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property CardSerial As String

    ''' <summary>
    ''' The transaction reference returned by the Gift Card service provider
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property Reference As String

    ''' <summary>
    ''' The balance of the card after the action has been performed
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property Balance As Decimal

    ''' <summary>
    ''' The Expiry Date of the card as return by the Gift Card service provider
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property ExpiryDate As Date

End Class