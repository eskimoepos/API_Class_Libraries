Imports System.ComponentModel.DataAnnotations

''' <summary>
''' The Barcode Info Class. Contains information about a barcode scanned
''' </summary>
Public Class clsBarcodeInfo
    Inherits EskimoBaseClass

    ''' <summary>
    ''' Information about the product itself
    ''' </summary>
    ''' <returns></returns>
    Property ProductInfo As clsProductCode

    ''' <summary>
    ''' Sales and Inward counts for the Current Year
    ''' </summary>
    ''' <returns></returns>
    Property CurrentYear As clsTotals

    ''' <summary>
    ''' Sales and Inward counts for the Previous Year
    ''' </summary>
    ''' <returns></returns>
    Property PreviousYear As clsTotals

    ''' <summary>
    ''' Sales and Inward counts for two years ago
    ''' </summary>
    ''' <returns></returns>
    Property MinusTwoYears As clsTotals

    ''' <summary>
    ''' The current stock level in Stock Location 1
    ''' </summary>
    ''' <returns></returns>
    Property CurrentStock1 As Integer

    ''' <summary>
    ''' The current stock level in Stock Location 2
    ''' </summary>
    ''' <returns></returns>
    Property CurrentStock2 As Integer

    ''' <summary>
    ''' The current stock level in Stock Location 3
    ''' </summary>
    ''' <returns></returns>
    Property CurrentStock3 As Integer

    ''' <summary>
    ''' The amount of stock available in other branches/outlets
    ''' </summary>
    ''' <returns></returns>
    Property GroupStock As Integer

End Class

Public Class clsTotals
    Sub New()

    End Sub

    Sub New(Sales As Integer, Inwards As Integer)
        Me.SalesTotal = Sales
        Me.GoodsInwardTotal = Inwards
    End Sub

    ''' <summary>
    ''' The amount of times this item has been sold within the period selected
    ''' </summary>
    ''' <returns></returns>
    Property SalesTotal As Integer

    ''' <summary>
    ''' The amount of times this item has been received in from a supplier's order within the period selected
    ''' </summary>
    ''' <returns></returns>
    Property GoodsInwardTotal As Integer
End Class