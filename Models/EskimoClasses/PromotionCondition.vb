Imports System.ComponentModel.DataAnnotations

Public Class clsPromotionCondition

    Inherits EskimoBaseClass

    ''' <summary>
    ''' The part of the sale that we are checking. See enum for the list of values.
    ''' </summary>
    ''' <returns></returns>
    <EnumDataType(GetType(ConditionObjectEnum))>
    Property ConditionObject As ConditionObjectEnum

    ''' <summary>
    ''' The maths operator to use for the calculation ( &#60; , &#61; , &#62;  etc.) 
    ''' </summary>
    ''' <returns></returns>
    <EnumDataType(GetType(ConditionOperatorEnum))>
    Property ConditionOperator As ConditionOperatorEnum

    ''' <summary>
    ''' The order in which to evaluate the conditions. Seeing as all the conditions must be met in order for the promotion to apply anyway, this is only useful really if one of the conditions is likely to take longer to evaluate that the others.
    ''' </summary>
    ''' <returns></returns>
    Property OrderBy As Integer

    ''' <summary>
    ''' A decimal value to be used in the equation where applicable. This is likely to be used in conjuntion with the Condition Object being (2) Order Value
    ''' </summary>
    ''' <returns></returns>
    Property DecimalValue As Decimal?

    ''' <summary>
    ''' An integer value to be used in the equation where applicable. This is likely to be used in conjunction with the Condition Object being (1) Source Code or (3) Shipping Country and this value would represent the ID.
    ''' </summary>
    ''' <returns></returns>
    Property IntegerValue As Integer?

    ''' <summary>
    ''' A list of values. Only relevant if the ConditionOperator is (6) Within.
    ''' </summary>
    ''' <returns></returns>
    Property Values As List(Of clsPromotionConditionValue)

    ''' <summary>
    ''' Readonly. A human-readable description of what the condition requires.
    ''' </summary>
    ''' <returns></returns>
    ReadOnly Property FriendlyOutline As String
        Get
            Dim strReturn As String = ""
            Dim strValue As String = ""

            Select Case Me.ConditionObject
                Case ConditionObjectEnum.SourceCode
                    strReturn = "Source Code"
                    If Me.ConditionOperator <> ConditionOperatorEnum.Within Then strValue = Me.IntegerValue
                Case ConditionObjectEnum.OrderValue
                    strReturn = "Order Value"
                    strValue = Me.DecimalValue.AsMoney
                Case ConditionObjectEnum.ShippingCountry
                    strReturn = "Shipping Country ID"
                    If Me.ConditionOperator <> ConditionOperatorEnum.Within Then strValue = Me.IntegerValue
                Case ConditionObjectEnum.RelevantProductsPresent
                    strReturn = "Relevant Products"
            End Select

            Select Case Me.ConditionOperator
                Case ConditionOperatorEnum.Equals
                    strReturn += " must ="
                Case ConditionOperatorEnum.LessThan
                    strReturn += " must <"
                Case ConditionOperatorEnum.GreaterThan
                    strReturn += " must >"
                Case ConditionOperatorEnum.GreaterThanOrEqualTo
                    strReturn += " must >="
                Case ConditionOperatorEnum.LessThanOrEqualTo
                    strReturn += " must <="
                Case ConditionOperatorEnum.Within
                    strReturn += " must be in list"
                Case ConditionOperatorEnum.NotEqualTo
                    strReturn += " must !="
            End Select

            strReturn += $" {strValue}"

            Return strReturn
        End Get
    End Property

    Enum ConditionObjectEnum

        ''' <summary>
        ''' The Sales Code (or Source Code) applied to the Sale
        ''' </summary>
        SourceCode = 1

        ''' <summary>
        ''' The value of the order, excluding shipping charge.
        ''' </summary>
        OrderValue = 2

        ''' <summary>
        ''' The country that the Delivery Address is set to. 
        ''' </summary>
        ShippingCountry = 3

        ''' <summary>
        ''' The products in the basket must match those that have been defined in the 'ProductSelection' collection.
        ''' </summary>
        RelevantProductsPresent = 4

    End Enum

    Enum ConditionOperatorEnum

        ''' <summary>
        ''' =
        ''' </summary>
        Equals = 1

        ''' <summary>
        ''' &#60;
        ''' </summary>
        LessThan = 2

        ''' <summary>
        ''' &#62;
        ''' </summary>
        GreaterThan = 3

        ''' <summary>
        ''' &#62;=
        ''' </summary>
        GreaterThanOrEqualTo = 4

        ''' <summary>
        ''' &#60;=
        ''' </summary>
        LessThanOrEqualTo = 5

        ''' <summary>
        ''' IN (in SQL)
        ''' </summary>
        Within = 6

        ''' <summary>
        ''' !=
        ''' </summary>
        NotEqualTo = 7
    End Enum
End Class

Public Class clsPromotionConditionValue

    ''' <summary>
    ''' This is the value. This depends on the Condition Object as to what this relates to. It could be a Source Code ID or a Country ID for example. 
    ''' </summary>
    ''' <returns></returns>
    Property IntergerValue As Integer

    ''' <summary>
    ''' Not necessary to display this to the till operator, but could be used for diagnosing why a promotion did not apply when expected for example.
    ''' </summary>
    ''' <returns></returns>
    Property FriendlyTitle As String

    ''' <summary>
    ''' Optional Further notes about the value. 
    ''' </summary>
    ''' <returns></returns>
    Property Notes As String
End Class