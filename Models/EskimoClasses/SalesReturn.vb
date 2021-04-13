Public Class clsSalesReturn

    Inherits EskimoBaseClass

    Property SaleDate As DateTime
    Property Lines As IEnumerable(Of clsSalesReturnLine)
    Property CarriageLine As clsSalesCarriageReturnLine
End Class

Public Class clsSalesReturnLine
    Inherits clsSalesReturnLineBase

    Property PLU As String
    Property OriginalOrderQty As Integer
    Property QtyRefunded As Integer
    Property UnitWeight As Decimal?
    Property SaleReference As String
    Property Line As Integer

End Class

Public Class clsSalesCarriageReturnLine
    Inherits clsSalesReturnLineBase

    Property AmountRefunded As Decimal

End Class

Public Class clsSalesReturnLineBase
    Property Description As String
    Property UnitPricePaid As Decimal
    Property OtherInfo As String
    Property VatID As Integer
End Class