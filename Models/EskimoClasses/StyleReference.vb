Imports System.ComponentModel.DataAnnotations

''' <summary>
''' A string code to tie multiple PLUs together that are the same product, but that come in different colours/sizes.
''' </summary>
Public Class clsStyleReference

    Inherits EskimoBaseClass

    Implements IValidatableObject

    <Required>
    <StringLength(20)>
    Property StyleID As String

    <Required>
    <StringLength(30)>
    Property DefaultTillDescription As String

    <Required>
    <StringLength(4000)>
    Property DefaultFullDescription As String

    <Required>
    Property DefaultProductDepartmentID As Integer

    <Required>
    Property DefaultSupplierID As Integer

    <Required>
    Property ProductTypeID As Integer

    <Required>
    Property ShopVisibility As clsShopVisibility

    <StringLength(50)>
    Property PersonalisationText As String
    Property PersonalisationSurCharge As Decimal

    <ValidCustomer>
    Property CustomerID As String = "000-000000"

    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim lst As New List(Of ValidationResult)

        If PersonalisationSurCharge < 0 Then lst.Add(New ValidationResult("The PersonalisationSurCharge cannot be negative"))

        Return lst
    End Function

End Class

