Imports System.IO

Public Class clsInvoice
    Property InvoiceId As Integer
    Property StoreId As String
    Property CustomerId As String
    Property DateRaised As Date
    Property IsCredit As Boolean
    Property Notes As String
    Property OperatorId As String
    Property WebId As String
    Property Lines As New List(Of clsSalesItemExt)
End Class
