Imports System.ComponentModel.DataAnnotations

Public Class ProductSearchArguments
    Implements iControllerArguments

    Property ProductDescription As String
    Property PLU As String
    Property GroupDescription As String
    Property DepartmentDescription As String
    Property SupplierName As String
    Property StyleReference As String
    Property TradeCustomerName As String

    Property SourceCodeID As Integer?

    <ValidCustomer>
    Property CustomerID As String

    <Required>
    <Range(1, 1000, ErrorMessage:="No more than 1000 can returned in a search")>
    Property MaxRecords As Long = 200

End Class
