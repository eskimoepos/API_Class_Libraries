Imports EskimoClassLibraries

Public Class clsCustomerHistory
    Property CustomerName As String
    Property CustomerNarrative As List(Of clsNarrativeEntry)
    Property Orders As List(Of clsCustomerHistorySale)

    'Property DatePlaced As Date
    'Property RefNumber As String
    'Property CustomerName As String
    'Property ShippingCharge As Decimal
    'ReadOnly Property TotalOrder As Decimal
    '    Get
    '        Dim d As Decimal = Me.ShippingCharge
    '        d += Me.OrderedItems.Sum(Function(x) x.LinePrice)
    '        Return d
    '    End Get
    'End Property
    'Property OrderedItems As List(Of clsHistoricOrderLine)

End Class

Public Class clsNarrativeEntry
    Property EntryDate As Date
    Property Title As String
    Property Entry As String
    Property OperatorName As String
End Class

Public Class clsCustomerHistorySale
    Inherits clsSale

    Private order_total As Decimal
    Private use_order_total As Boolean

    Sub New()

    End Sub

    Sub New(_order_total As Decimal)
        order_total = _order_total
        use_order_total = True
    End Sub
    Public Overrides ReadOnly Property TotalOrder As Decimal
        Get
            If use_order_total Then
                Return order_total
            Else
                Return MyBase.TotalOrder
            End If

        End Get
    End Property

    Property OrderRef As String

End Class


'Public Class clsHistoricOrderLine
'    Property PLU As String
'    Property Description As String
'    Property LinePrice As Decimal
'    Property Discount As Decimal

'End Class