Imports System.ComponentModel.DataAnnotations

Public Class GetReceiptsParams
    <Required>
    Property [Date] As Date
    Property Store As String
    Property TillNumber As Integer?
    Property ReceiptNumber As Integer?
    Property ReceiptType As ReceiptTypeEnum?
End Class
