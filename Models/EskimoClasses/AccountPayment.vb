Imports System.ComponentModel.DataAnnotations

Public Class clsAccountPayment
    Inherits clsAccountPaymentBase

    Property PaymentID As Integer
    Property TillNumber As Integer
    Property ReceiptNumber As Integer

End Class

Public Class clsAccountPaymentBase
    Inherits EskimoBaseClass

    <Required>
    Property PaymentDate As DateTime

    <Required>
    <Range(0.01, Decimal.MaxValue, ErrorMessage:="The Amount must be a positive number")>
    Property Amount As Decimal

    <Required>
    <StringLength(10, ErrorMessage:=clsCustomer.CustomerLengthMsg, MinimumLength:=10)>
    <RegularExpression(clsCustomer.CustomerIDFormat)>
    <ValidCustomer>
    Property CustomerID As String

End Class