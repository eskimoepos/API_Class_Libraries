Imports System.ComponentModel.DataAnnotations

Public Class clsQuote

    Inherits clsPreSaleBase
    Implements IValidatableObject

    Enum QuoteStatusEnum

        ''' <summary>
        ''' Quote has not been fully finished yet. It is still being prepared.
        ''' </summary>
        InPreparation = 0

        ''' <summary>
        ''' The quote is live until the expiry date.
        ''' </summary>
        Live = 1

        ''' <summary>
        ''' The quote has been converted into a sale
        ''' </summary>
        SuccessfullyConverted = 2

        ''' <summary>
        ''' The retailer will not be receiving this order - the customer has gone elsewhere.
        ''' </summary>
        Unsuccessful = 3

        ''' <summary>
        ''' This quote has been deleted.
        ''' </summary>
        Deleted = 4

        ''' <summary>
        ''' This Quote has been superseded by a new quote
        ''' </summary>
        Replaced = 5

    End Enum

    Property CustomerName As String
    Property OperatorName As String
    <EnumDataType(GetType(QuoteStatusEnum))>
    Property Status As QuoteStatusEnum = QuoteStatusEnum.Live
    Property ValidUntil As Date
    Property ReplacementQuoteNum As Integer?

    '(case when [CusQuoteStatus]=(0) then 'Preparation' when [CusQuoteStatus]=(1) then 'Live' when [CusQuoteStatus]=(2) then 'Successful' when [CusQuoteStatus]=(3) then 'Unsuccessful' when [CusQuoteStatus]=(4) then 'Deleted'  end)

    '    Property ID As Integer?

    '    <StringLength(3, ErrorMessage:="The StoreID must be 3 digits.", MinimumLength:=3)>
    '    <Required>
    '    Property StoreID As String

    '    ''' <summary>
    '    ''' The date the layaway was created
    '    ''' </summary>
    '    ''' <returns></returns>
    '    Property DateStored As DateTime

    '    ''' <summary>
    '    ''' The ID of the sales clerk (or operator) that performed the layaway
    '    ''' </summary>
    '    ''' <returns></returns>
    '    Property OperatorID As String = "SYSTEM"

    '    <Required>
    '    Property Products As IEnumerable(Of clsSalesItem)

    '    Function ItemsValue() As Decimal
    '        Return Products.Sum(Function(x) x.LinePrice)
    '    End Function

    '    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
    '        Dim results As New List(Of ValidationResult)


    '        Return results

    '    End Function

    '    Property MailOrderValues As clsLayawayMailOrderValues

    '    ''' <summary>
    '    ''' The Customer ID selected against the sale.
    '    ''' </summary>
    '    ''' <returns></returns>
    '    Property CustomerID As String


End Class

Public Class QuoteInsert
    <Range(1, Decimal.MaxValue)>
    <Required>
    Property Till As Integer
    <Range(1, Decimal.MaxValue)>
    <Required>
    Property Receipt As Integer
    <Required>
    Property Quote As clsQuote
End Class