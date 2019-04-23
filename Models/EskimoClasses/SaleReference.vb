Imports System.ComponentModel.DataAnnotations

Public Class clsSaleReference

    Inherits EskimoBaseClass

    <Required>
    Property TillNumber As Integer

    ''' <summary>
    ''' Shop Code that the sale is assigned to. See api/Shops/All
    ''' </summary>
    <StringLength(3, ErrorMessage:="The Eskimo Store Number length must be 3 characters.", MinimumLength:=3)>
    <Required>
    Property StoreNumber As String

    <Required>
    <Range(1, Integer.MaxValue)>
    Property ReceiptNumber As Integer

    Property Orders As New List(Of OrderReference)

End Class

Public Class OrderReference

    <Required>
    Property ID As Integer

    <Required>
    Property OrderType As Integer
End Class