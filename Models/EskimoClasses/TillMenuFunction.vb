Imports System.ComponentModel.DataAnnotations

Public Class clsTillMenuFunction
    Inherits EskimoBaseClass

    <Required>
    Property Name As String
    <Required>
    Property BackColour As String
    <Required>
    Property TextColour As String
    <Required>
    Property FunctionAction As FunctionActionEnum

    <Required>
    Property Position As Integer
    Enum FunctionActionEnum
        Customer = 1
        PrintReceipt = 2
        Cancel = 3
        SearchProduct = 4
    End Enum

End Class
