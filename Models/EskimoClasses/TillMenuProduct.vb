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
    Property Outline As String
    Property Supplier As String
    Property StyleReference As String
    Property TradeCustomerID As String
    Property TradeCustomerName As String
    <Required>
    Property IsOpenPriced As Boolean
    <Required>
    Property IsOpenDescription As Boolean
    Property IsWebVisible As Boolean
    Property ColourName As String
    Property Size As String
    Property Prices As IEnumerable(Of clsPrice)
    Property RRP As Decimal
    Property TaxID As Integer
    Property TaxRate As Decimal
    Property StockLevel As Integer
    Property StockLevel1 As Integer
    Property StockLevel2 As Integer
    Property StockLevel3 As Integer
    Property StockWarnLevel As Integer?
    Property BuyTodayPrice As Decimal?
    Property NoDiscountAllowed As Boolean

    Property WeightValue As Decimal?
    Property WeightMeasureUnit As Integer?

    Property ProductType As String
    Property Season As String
    Property Brand As String
    Property Gender As String
    Property SupplierCode As String
    Property CaseQty As Integer

    Property OnTransfer As Integer
    Property OnPurchaseOrder As Integer
    Property OnForwardOrder As Integer
    Property Expected As Integer
    Property OnReserve As Integer
    Property OnCustomerOrder As Integer
    Property OnCustomerSale As Integer
    Property OnWebSale As Integer

    Property BuyCost As Decimal
    Property AdditionalCost As Decimal
    Property TotalCost As Decimal
    Property StockMinimum As Integer?
    Property StockMaximum As Integer?
    Property CategoryIds As List(Of String)
    Property StateId As Integer?
    Property ProductImageCount As Integer?
    Property VariantImageCount As Integer?
End Class
