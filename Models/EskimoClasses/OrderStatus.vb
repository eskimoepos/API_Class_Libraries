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
End Class
