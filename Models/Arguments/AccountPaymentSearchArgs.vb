Public Class clsAccountPaymentSearchArgs
    Implements iControllerArguments

    Property Till As Integer?
    Property Receipt As Integer?
    <ValidCustomer>
    Property CustomerID As String
    Property DateFrom As Date?
    Property DateTo As Date?
End Class
