Imports System.ComponentModel.DataAnnotations

Public Class StringLengthListAttribute
    Inherits StringLengthAttribute

    Public Overrides Function IsValid(value As Object) As Boolean

        If value Is Nothing Then Return True

        If Not value.GetType = GetType(List(Of String)) Then
            Return False
        End If

        For Each strItem In TryCast(value, List(Of String))
            If strItem.Length > MaximumLength OrElse strItem.Length < MinimumLength Then Return False
        Next

        Return True

    End Function

    Public Overrides Function FormatErrorMessage(name As String) As String

        Return $"The field {name} contains entries that are longer than {Me.MaximumLength} characters in length"

    End Function

    Public Sub New(ByVal maximumLength As Integer)
        MyBase.New(maximumLength)
    End Sub

End Class
