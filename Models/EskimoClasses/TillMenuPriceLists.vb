Imports System.ComponentModel.DataAnnotations

Public Class clsTillMenuPriceListItem
    <Required>
    Property PLU As String
    Property Qty As Integer
    Property Price As Decimal
    Property PriceListID As Integer
End Class

Public Class clsTillMenuPriceList
    Property ID As Integer
    <Required>
    Property Code As String
    Property Description As String
    Property PercentageDiscount As Decimal?
    Property PriceListMaster As Integer?
End Class