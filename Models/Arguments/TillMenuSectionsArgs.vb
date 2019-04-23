Imports System.ComponentModel.DataAnnotations

Public Class TillMenuSectionsArgs
    <Required>
    Property TillNumber As Integer
    <Required>
    <StringLength(3, ErrorMessage:="The StoreNumber must be 3 digits.", MinimumLength:=3)>
    Property StoreNumber As String
End Class
