Imports System.ComponentModel.DataAnnotations

Public Class clsAccountAdjustmentInfo
    Inherits clsAccountAdjustment

    Property Id As Integer

End Class

Public Class clsAccountAdjustment
    Inherits EskimoBaseClass
    Implements IValidatableObject

    <EnumDataType(GetType(clsAccountActivity.AccountActivityTypeEnum))>
    <Required>
    Property AdjustmentType As clsAccountActivity.AccountActivityTypeEnum

    <Required>
    Property AdjustmentDate As DateTime

    <Required>
    Property Amount As Decimal

    <Required>
    <StringLength(10, ErrorMessage:=clsCustomer.CustomerLengthMsg, MinimumLength:=10)>
    <RegularExpression(clsCustomer.CustomerIDFormat)>
    <ValidCustomer>
    Property CustomerID As String

    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim lst As New List(Of ValidationResult)

        Select Case Me.AdjustmentType
            Case clsAccountActivity.AccountActivityTypeEnum.OpeningBalance
            Case clsAccountActivity.AccountActivityTypeEnum.Payment, clsAccountActivity.AccountActivityTypeEnum.Sale
                lst.Add(New ValidationResult($"The Adjustment type {Me.AdjustmentType.ToString} cannot be used in this context"))
            Case Else
                If Me.Amount < 0 Then
                    lst.Add(New ValidationResult("The Amount must be a positive number"))
                End If
        End Select

        Return lst
    End Function
End Class