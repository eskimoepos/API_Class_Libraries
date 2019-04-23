Imports System.ComponentModel.DataAnnotations

Public Class HistoricOrderSearchArguments
    Implements iControllerArguments
    Implements IValidatableObject

    <Required>
    Property CustomerID As String
    <Required>
    Property TillNumber As Integer
    <Required>
    <StringLength(3, ErrorMessage:="The StoreNumber must be 3 digits.", MinimumLength:=3)>
    Property StoreNumber As String
    Property SpecificOrder As String
    Property DateFrom As Date?
    Property DateTo As Date?
    Property IncludeNarrative As Boolean
    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim lst As New List(Of ValidationResult)

        If SpecificOrder Is Nothing AndAlso DateFrom Is Nothing Then
            lst.Add(New ValidationResult("DateFrom not passed"))
        End If

        If SpecificOrder Is Nothing AndAlso DateTo Is Nothing Then
            lst.Add(New ValidationResult("DateTo not passed"))
        End If

        If SpecificOrder IsNot Nothing AndAlso DateFrom IsNot Nothing Then
            lst.Add(New ValidationResult("Do not pass DateFrom if searching for a specific order"))
        End If

        If SpecificOrder IsNot Nothing AndAlso DateTo IsNot Nothing Then
            lst.Add(New ValidationResult("Do not pass DateTo if searching for a specific order"))
        End If

        Return lst
    End Function
End Class
