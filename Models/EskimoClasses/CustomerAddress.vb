Imports System.ComponentModel.DataAnnotations

Public Class clsCustomerAddress
    Inherits clsAddress

    Sub New()

    End Sub
    Sub New(r As SqlClient.SqlDataReader)
        Me.New(New DataRecord(r))
    End Sub

    Sub New(r As DataRow)
        Me.New(New DataRecord(r))
    End Sub

    Sub New(r As DataRecord)
        MyBase.New(r)

        Me.CustomerID = Nz(r("AddressCustomerID"), Nothing)
        Me.Reference = Nz(r("AddressRef"), Nothing)

    End Sub

    Public Const CustomerAddressRefLengthMsg As String = "The Address Reference length must not exceed 12 characters."

    <Required>
    <StringLength(12, ErrorMessage:=clsCustomerAddress.CustomerAddressRefLengthMsg, MinimumLength:=1)>
    Property Reference As String

    <StringLength(10, ErrorMessage:=clsCustomer.CustomerLengthMsg, MinimumLength:=10)>
    <RegularExpression(clsCustomer.CustomerIDFormat)>
    <ValidCustomer>
    <Required>
    Property CustomerID As String

End Class
