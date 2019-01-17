Imports System.ComponentModel.DataAnnotations

Public Class clsTillMenuSourceCode

    <Required>
    Property CodeID As Integer
    <Required>
    Property SourceCode As String
    Property CodeDescription As String
    Property ValidFrom As Date?
    Property ValidTo As Date?
    Property Active As Boolean
    'Property PriceList1 As clsTillMenuPriceList
    'Property PriceList2 As clsTillMenuPriceList
    Property PriceList1 As Integer?
    Property PriceList2 As Integer?
    Property RequiresElevation As Boolean
End Class
