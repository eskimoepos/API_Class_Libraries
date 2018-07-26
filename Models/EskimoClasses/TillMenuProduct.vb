Imports System.ComponentModel.DataAnnotations

Public Class clsTillMenuProduct

    Inherits EskimoBaseClass

    <Key>
    <Required>
    Property SKU As String
    Property AdditionalSKUs As String()
    Property Group As String
    Property Department As String
    Property Description As String
    Property Supplier As String
    Property StyleReference As String
    Property TradeCustomerID As String
    Property TradeCustomerName As String
    <Required>
    Property IsOpenPriced As Boolean
    <Required>
    Property IsOpenDescription As Boolean
End Class
