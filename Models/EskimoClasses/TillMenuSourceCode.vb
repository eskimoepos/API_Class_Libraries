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
End Class
