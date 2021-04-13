Public Class clsInvoicePaymentSearchArgs
    Implements iControllerArguments

    <ValidCustomer>
    Property CustomerID As String
    Property DateFrom As Date?
    Property DateTo As Date?
    Property InvoiceID As Integer?
End Class
