Imports System.ComponentModel.DataAnnotations

Public Class clsAccountActivityInfo
    Inherits clsAccountActivity

    Property Id As Integer
    Property EntryIndex As Integer
    ReadOnly Property ActivityTypeText As String
        Get
            Return Me.ActivityType.ToString
        End Get
    End Property

End Class

Public Class clsAccountActivity
    Inherits EskimoBaseClass
    Implements IValidatableObject

    Enum AccountActivityTypeEnum

        ''' <summary>
        ''' Used to set the initial balanace for a customer. Useful if bringing data across from another system.
        ''' </summary>
        OpeningBalance = 0

        ''' <summary>
        ''' Driven by the CustomerAccountValuePaid field when using the endpoint POST api/Orders/Insert
        ''' </summary>
        Sale = 1

        ''' <summary>
        ''' Any payments into the customer's account
        ''' </summary>
        Payment = 2

        ''' <summary>
        ''' Any manual adjustments to increment the balance to what it should be.
        ''' </summary>
        AdjustmentCredit = 3

        ''' <summary>
        ''' Any manual adjustments to decrement the balance to what it should be.
        ''' </summary>
        AdjustmentDebit = 4

    End Enum

    <EnumDataType(GetType(AccountActivityTypeEnum))>
    <Required>
    Property ActivityType As AccountActivityTypeEnum

    <Required>
    Property ActivityDate As DateTime

    Property BalanceBefore As Decimal

    <Required>
    Property Amount As Decimal

    Property BalanceAfter As Decimal

    <Required>
    <StringLength(10, ErrorMessage:=clsCustomer.CustomerLengthMsg, MinimumLength:=10)>
    <RegularExpression(clsCustomer.CustomerIDFormat)>
    <ValidCustomer>
    Property CustomerID As String
    Property Till As Integer?
    Property Receipt As Integer?
    Property InvoiceId As Integer?
    Property WebOrderId As Integer?
    Property OrderExternalId As String

    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim lst As New List(Of ValidationResult)

        'Select Case Me.ActivityType
        '    Case AccountActivityTypeEnum.OpeningBalance
        '    Case Else
        '        If Me.Amount < 0 Then
        '            lst.Add(New ValidationResult("The Amount must be a positive number"))
        '        End If
        'End Select

        Return lst
    End Function
End Class