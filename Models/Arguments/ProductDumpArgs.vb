Imports System.ComponentModel.DataAnnotations

Public Class ProductDumpArgs

    Property DateFrom As DateTime

    ''' <summary>
    ''' Optional. If paging information is sent in the request, it will be adhered to. If omitted, the entire result set will be returned.
    ''' </summary>
    ''' <returns></returns>
    Property PageSize As Integer?
    Property PageRequired As Integer?

    Property TillNumber As Integer?

    <StringLength(3, ErrorMessage:="The StoreNumber must be 3 digits.", MinimumLength:=3)>
    Property StoreNumber As String

    Property PLU As String
End Class
