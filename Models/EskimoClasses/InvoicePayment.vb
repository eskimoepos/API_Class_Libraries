Public Class clsInvoicePayment
    Property ID As Integer
    <ValidCustomer>
    Property CustomerID As String
    Property InvoiceID As Integer
    Property InvoiceDate As Date
    Property PaymentDate As Date
    Property ValuePaid As Decimal
    Property TenderID As Integer
    Property StoreID As String
    Property TillNumber As Integer
    Property ReceiptNumber As Integer
End Class
