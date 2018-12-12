Imports System.ComponentModel.DataAnnotations

Public Class ProductDumpArgs

    Property DateFrom As DateTime

    ''' <summary>
    ''' Optional. If paging information is sent in the request, it will be adhered to. If omitted, the entire result set will be returned.
    ''' </summary>
    ''' <returns></returns>
    Property PageSize As Integer?
    Property PageRequired As Integer?
End Class
