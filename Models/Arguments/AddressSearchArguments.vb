Imports System.ComponentModel.DataAnnotations

Public Class clsAddressSearchArguments
    Inherits EskimoBaseClass

    <StringLength(10, ErrorMessage:=clsCustomer.CustomerLengthMsg, MinimumLength:=10)>
    <RegularExpression(clsCustomer.CustomerIDFormat)>
    <ValidCustomer>
    Property CustomerID As String

    <StringLength(20)>
    Property PostCode As String

    <StringLength(12, ErrorMessage:=clsCustomerAddress.CustomerAddressRefLengthMsg, MinimumLength:=1)>
    Property Reference As String

End Class
