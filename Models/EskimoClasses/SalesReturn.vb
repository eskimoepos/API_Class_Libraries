Public Class clsSalesReturn

    Inherits EskimoBaseClass

    Property SaleDate As DateTime
    Property Lines As IEnumerable(Of clsSalesReturnLine)
End Class

Public Class clsSalesReturnLine
    Property SaleReference As String
    Property Line As Integer
    Property PLU As String
    Property Description As String
    Property UnitPricePaid As Decimal
    Property OriginalOrderQty As Integer
    Property QtyRefunded As Integer
    Property UnitWeight As Decimal?
    Property OtherInfo As String
    Property VatID As Integer

End Class