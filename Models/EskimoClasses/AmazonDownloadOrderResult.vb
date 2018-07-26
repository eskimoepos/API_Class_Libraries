Public Class clsAmazonDownloadOrderResult
    Inherits EskimoBaseClass

    Property OrdersFound As Integer
    ReadOnly Property OrdersAlreadyImported As Integer
        Get
            Return Me.OrdersFound - Me.NewOrdersImported - Me.ImportFailures.Count
        End Get
    End Property
    Property NewOrdersImported As Integer
    Property OrdersFailedToImport As Integer
    Property ImportFailures As IEnumerable(Of ImportFailure)
    Property NewOrders As IEnumerable(Of clsSaleReference)
End Class
Public Class ImportFailure
    Property OrderID As String
    Property ErrorMessage As String
End Class