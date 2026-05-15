Imports System.ComponentModel.DataAnnotations

Public Class clsOrderStatus
    Inherits EskimoBaseClass

    <Required>
    Property ID As Integer

    <Required>
    Property Description As String

    Property OrderBy As Integer

    Property Active As Boolean
    Property WebStatusText As String

    Property TriggeringActions As New List(Of clsAction)
End Class
