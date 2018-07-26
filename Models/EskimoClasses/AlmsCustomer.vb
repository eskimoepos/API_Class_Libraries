Imports System.ComponentModel.DataAnnotations
Imports System.Reflection

Public Class AlmsCustomer
    Inherits clsCustomer

    Implements IValidatableObject
    Property Title As String
    Property CountryName As String
    Public Overloads Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim lst As New List(Of ValidationResult)

        lst.AddRange(MyBase.Validate(validationContext))

        If Me.Surname Is Nothing OrElse Me.Surname.Trim = "" Then lst.Add(New ValidationResult("The surname field is required for Alms."))
        If Me.ID Is Nothing Then lst.Add(New ValidationResult("The Customer ID field is required for Alms."))
        If Me.CountryName Is Nothing Then lst.Add(New ValidationResult("The CountryName field is required for Alms."))

        Return lst.AsEnumerable
    End Function

    Sub New()

    End Sub

    Sub New(c As clsCustomer)
        Dim pi As PropertyInfo

        For Each prop As PropertyInfo In c.GetType.GetProperties
            pi = c.GetType.GetProperty(prop.Name)
            pi.SetValue(Me, prop.GetValue(c, Nothing), Nothing)
        Next
    End Sub

End Class
