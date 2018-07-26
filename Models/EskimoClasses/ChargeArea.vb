Imports System.ComponentModel.DataAnnotations

Public Class clsChargeArea
    Inherits EskimoBaseClass
    Property ID As Integer
    Property Description As String
    Property Charges As List(Of clsChargeNumber)
End Class

Public Class clsChargeNumber
    Inherits EskimoBaseClass
    Property ScopeNumber As Integer     'ticket/table
    <Required>
    Property Name As String
End Class