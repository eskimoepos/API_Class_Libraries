Imports System.ComponentModel.DataAnnotations

Public Class SettleInvoiceArguments
    <Required>
    Property InvoiceId As Integer
    <Required>
    Property StoreId As String
    <Required>
    Property PaymentDate As Date
    <Required>
    Property Amount As Decimal
    <Required>
    Property TenderId As Integer
    Property PaymentNotes As String
End Class
