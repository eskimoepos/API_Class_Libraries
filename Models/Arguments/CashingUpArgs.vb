Imports System.ComponentModel.DataAnnotations

Public Class clsCashingUpArgs
    Inherits EskimoBaseClass
    Implements iControllerArguments
    Implements iCashingUpArgs

    <Required>
    Property DateFrom As DateTime Implements iCashingUpArgs.DateFrom

    <Required>
    Property DateTo As DateTime Implements iCashingUpArgs.DateTo

    <StringLength(3, ErrorMessage:="The StoreNumber must be 3 digits.", MinimumLength:=3)>
    Property StoreNumber As String Implements iCashingUpArgs.StoreNumber

    Property OperatorIDs As String Implements iCashingUpArgs.OperatorIDs

    Property TillIDs As String Implements iCashingUpArgs.TillIDs

End Class

Public Class clsCashingUpBreakdownArgs
    Inherits clsCashingUpArgs

    Implements iCashingUpArgs

    <Required>
    Property FilterColumn As Integer

    Property TillID As Integer?

End Class

Public Interface iCashingUpArgs
    <Required>
    Property DateFrom As DateTime

    <Required>
    Property DateTo As DateTime

    <StringLength(3, ErrorMessage:="The StoreNumber must be 3 digits.", MinimumLength:=3)>
    Property StoreNumber As String

    Property OperatorIDs As String

    Property TillIDs As String

End Interface