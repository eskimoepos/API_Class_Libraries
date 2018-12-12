Imports System.Runtime.CompilerServices

Public Module modExtentions
    <Extension()>
    Public Function AsMoney(ByVal dInput As Decimal) As String
        Return String.Format("{0:C}", dInput)
    End Function

    <Extension()>
    Public Function AsMoney(ByVal dInput As Decimal?) As String
        If dInput Is Nothing Then Return "null"
        Return String.Format("{0:C}", dInput)
    End Function
End Module
