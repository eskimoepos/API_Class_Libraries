Imports System.ComponentModel.DataAnnotations

Public Class clsPLU

    Inherits EskimoBaseClass

    Implements IValidatableObject

    <Required>
    <StringLength(35)>
    Property PLUNumber As String

    <StringLength(35)>
    Property SecondaryPLUNumber As String

    <Required>
    <StringLength(30)>
    Property TillDescription As String

    <Required>
    <StringLength(4000)>
    Property FullDescription As String

    <Required>
    Property ProductDepartmentID As Integer

    <Required>
    Property SupplierID As Integer

    <Required>
    Property TaxCodeID As Integer
    Property State As Integer?

    <Required>
    Property ProductTypeID As Integer

    Property Price1 As Decimal
    Property Price2 As Decimal
    Property Price3 As Decimal
    Property Price4 As Decimal
    Property Price5 As Decimal
    Property Price6 As Decimal
    Property Price7 As Decimal
    Property Price8 As Decimal
    Property Price9 As Decimal
    Property Price10 As Decimal

    ''' <summary>
    ''' The Recommended Retail Price. Can be used to display a Saving for certain website carts. 
    ''' </summary>
    ''' <returns></returns>
    Property RRP As Decimal

    ''' <summary>
    ''' The ex-vat price to buy the item from the supplier
    ''' </summary>
    ''' <returns></returns>
    Property BuyCost As Decimal

    ''' <summary>
    ''' Optional. Code to tie multiple PLUs together that are the same product, but that come in different colours/sizes. See the Styles Controller.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(12)>
    Property StyleID As String

    <StringLength(6)>
    Property ColourID As String = "-1"

    <StringLength(50)>
    Property Size As String

    <StringLengthList(50)>
    Property AdditionalBarcodes As List(Of String)

    <Required>
    Property ShopVisibility As clsShopVisibility

    Property ShowOnWeb As Boolean

    <StringLength(50)>
    Property PersonalisationText As String
    Property PersonalisationSurCharge As Decimal

    <ValidCustomer>
    Property CustomerID As String = "000-000000"

    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim lst As New List(Of ValidationResult)

        If Me.StyleID IsNot Nothing Then
            If Me.StyleID.Trim = String.Empty Then
                lst.Add(New ValidationResult("StyleID must either be null or populated, not zero-length"))
            Else
                If String.IsNullOrEmpty(Me.ColourID) OrElse (Me.ColourID = "-1") Then
                    lst.Add(New ValidationResult("The ColourID property is required when the StyleID property is populated."))
                End If
                If String.IsNullOrEmpty(Me.Size) Then
                    lst.Add(New ValidationResult("The Size property is required when the StyleID property is populated."))
                End If
            End If
        End If

        If PersonalisationSurCharge < 0 Then lst.Add(New ValidationResult("The PersonalisationSurCharge cannot be negative"))
        If Me.Price1 < 0 Then lst.Add(New ValidationResult("The Price1 field cannot be negative "))
        If Me.Price2 < 0 Then lst.Add(New ValidationResult("The Price2 field cannot be negative "))
        If Me.Price3 < 0 Then lst.Add(New ValidationResult("The Price3 field cannot be negative "))
        If Me.Price4 < 0 Then lst.Add(New ValidationResult("The Price4 field cannot be negative "))
        If Me.Price5 < 0 Then lst.Add(New ValidationResult("The Price5 field cannot be negative "))
        If Me.Price6 < 0 Then lst.Add(New ValidationResult("The Price6 field cannot be negative "))
        If Me.Price7 < 0 Then lst.Add(New ValidationResult("The Price7 field cannot be negative "))
        If Me.Price8 < 0 Then lst.Add(New ValidationResult("The Price8 field cannot be negative "))
        If Me.Price9 < 0 Then lst.Add(New ValidationResult("The Price9 field cannot be negative "))
        If Me.Price10 < 0 Then lst.Add(New ValidationResult("The Price10 field cannot be negative "))

        Return lst
    End Function
End Class

