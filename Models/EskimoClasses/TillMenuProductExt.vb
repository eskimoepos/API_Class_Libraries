Imports System.ComponentModel.DataAnnotations

Public Class clsTillMenuProductExt

    Inherits EskimoBaseClass

    <Key>
    <Required>
    Property PLU As String
    Property SecondaryPLU As String
    'Property Group As String
    Property Department As String
    Property Description As String
    Property Prices As IEnumerable(Of clsPrice)
    Property Supplier As String
    Property StyleReference As String
    'Property TradeCustomerID As String
    Property TradeCustomerName As String

    '<Required>
    'Property IsOpenDescription As Boolean
    Property StockLevel As Integer

    ''' <summary>
    ''' See api/TaxCodes/All
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property TaxID As Integer
    <Required>
    Property IsOpenPriced As Boolean
    Property ColourName As String
    Property ColourValue As String
    Property Size As String
    Property StockWarnLevel As Integer?
    Property Weight As Long
    Property NoDiscountAllowed As Boolean
    Property AdditionalPLUs As New List(Of String)

End Class

Public Class clsPrice
    Property PriceLevel As Integer
    Property Price As Decimal
End Class