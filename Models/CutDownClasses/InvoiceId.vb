Imports System.ComponentModel.DataAnnotations

Public Class InvoiceId
    Inherits EskimoBaseClass

    <Required>
    Property Eskimo_Invoice_Id As Integer

    <Required>
    <StringLength(3)>
    Property Eskimo_Invoice_Store As String

    <StringLength(200)>
    Property Web_ID As String
End Class
