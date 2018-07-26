Imports System.ComponentModel.DataAnnotations

Public Class ValidCustomer
    Inherits ComponentModel.DataAnnotations.ValidationAttribute

    Protected Overrides Function IsValid(value As Object, validationContext As ValidationContext) As ValidationResult
        Dim strVal As String

        If value Is Nothing Then Return Nothing

        Try
            strVal = value
            If Not Text.RegularExpressions.Regex.IsMatch(strVal, clsCustomer.CustomerIDFormat) Then
                Throw New Exception("fail")
            End If
        Catch ex As Exception
            Return New ValidationResult("The Customer ID must be in the format 000-0012345")
        End Try

        Return Nothing

    End Function

    Public Overrides Function FormatErrorMessage(name As String) As String
        Return $"The parameter {name} must be in the format 001-123456. Regex pattern: {clsCustomer.CustomerIDFormat}"
    End Function

End Class
