Imports System.ComponentModel.DataAnnotations

Public Class UnitInfoArgs
    <Required>
    <StringLength(8, ErrorMessage:="The DeviceToken must be 8 digits.", MinimumLength:=8)>
    Property DeviceToken As String
End Class
