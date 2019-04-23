Imports System.ComponentModel.DataAnnotations

Public Class clsNextSaleArguments
    ''' <summary>
    ''' See api/Sales/Channels
    ''' </summary>
    ''' <returns></returns>
    Property ReserveOrderTypes As IEnumerable(Of Integer)

    <Required>
    Property TillNumber As Integer
    <Required>
    <StringLength(3, ErrorMessage:="The StoreNumber must be 3 digits.", MinimumLength:=3)>
    Property StoreNumber As String

End Class
