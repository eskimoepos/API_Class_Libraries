Imports System.ComponentModel.DataAnnotations

Public Class clsAccountActivitySearchArgs
    Implements iControllerArguments

    Property Till As Integer?
    Property Receipt As Integer?
    <ValidCustomer>
    Property CustomerID As String
    Property DateFrom As Date?
    Property DateTo As Date?

    <EnumDataTypeArrayAttribute(GetType(clsAccountActivity.AccountActivityTypeEnum))>
    <Required>
    Property Types As clsAccountActivity.AccountActivityTypeEnum()

End Class
