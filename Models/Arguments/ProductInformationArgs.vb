Imports System.ComponentModel.DataAnnotations

Public Class ProductInformationArgs
    <Required>
    Property PLU As String
    <Required>
    <StringLength(3, ErrorMessage:="The StoreNumber must be 3 digits.", MinimumLength:=3)>
    Property StoreNumber As String
End Class
