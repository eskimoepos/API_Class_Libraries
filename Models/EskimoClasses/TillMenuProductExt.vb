Imports System.ComponentModel.DataAnnotations

Public Class clsTillMenuProductExt

    Inherits EskimoBaseClass

    <Key>
    <Required>
    Property PLU As String
    ''' <summary>
    ''' Semicolon separated list of barcodes
    ''' </summary>
    ''' <returns></returns>
    Property AdditionalSKUs As String
    'Property Group As String
    Property Department As String
    Property Description As String
    Property Price As Decimal?
    Property Supplier As String
    Property StyleReference As String
    'Property TradeCustomerID As String
    Property TradeCustomerName As String
    '<Required>
    'Property IsOpenPriced As Boolean
    '<Required>
    'Property IsOpenDescription As Boolean
    Property StockLevel As Integer
End Class
