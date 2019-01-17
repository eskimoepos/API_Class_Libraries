Public Class clsTillMenuProductInfo
    Property PLU As String
    Property CompanyStock As clsCompanyStock
    Property OnPurchaseOrder As Integer
End Class

Public Class clsCompanyStock
    Property StockBreakdown As New List(Of clsShopStock)
    Property ExpectedDeliveryBreakdown As New List(Of clsExpectedDelivery)
    ReadOnly Property CompanyStock As Integer
        Get
            Return Me.StockBreakdown.Sum(Function(x) x.StockLevel)
        End Get
    End Property
    ReadOnly Property ExpectingQty As Integer
        Get
            Return Me.ExpectedDeliveryBreakdown.Sum(Function(x) x.Qty)
        End Get
    End Property

End Class

Public Class clsShopStock
    Property ShopID As String
    Property ShopName As String
    Property IsWarehouse As Boolean
    Property StockLevel As Integer
End Class

Public Class clsExpectedDelivery
    Property Qty As Integer
    Property ExpDate As Date
End Class