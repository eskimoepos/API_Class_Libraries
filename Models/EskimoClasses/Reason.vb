Imports System.ComponentModel.DataAnnotations

Public Class clsReason
    Enum ReasonAspectEnum
        Discount = 1
        Refund = 2
        PaidIn = 3
        PaidOut = 4
        VoidAll = 5
        SupplierReturn = 6
        StockMovement = 7
    End Enum

    Enum ReasonActionEnum
        NoAction = 0
        PutBackIntoStock = 1
        RememberForSupplierReturn = 2
        DisposeOfItem = 3
    End Enum
    <Required>
    Property ID As Integer
    Property Description As String
    <EnumDataType(GetType(ReasonAspectEnum))>
    Property UseageAspect As ReasonAspectEnum
    <EnumDataType(GetType(ReasonActionEnum))>
    Property StockAction As ReasonActionEnum
    Property Active As Boolean
    Property ExternalID As String

End Class
