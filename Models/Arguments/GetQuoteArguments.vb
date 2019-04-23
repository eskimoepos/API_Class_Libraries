Imports System.ComponentModel.DataAnnotations

Public Class GetQuoteArguments

    Implements iControllerArguments

    <StringLength(3, ErrorMessage:="The store ID must be 3 digits.", MinimumLength:=3)>
    Property StoreID As String

    'Property TillNumber As Integer?

    Property OperatorID As String
    Property ID As Integer?
    Property CustomerID As String
    Property DateFrom As Date?
    Property DateTo As Date?
    Property Status As clsQuote.QuoteStatusEnum?

End Class


