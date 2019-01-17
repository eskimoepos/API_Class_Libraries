Imports System.ComponentModel.DataAnnotations

Public Class clsPaginationSettings

    <Range(1, Integer.MaxValue, ErrorMessage:="The Page Required must be positive")>
    <Required>
    Property PageRequired As Integer

    <Range(1, Integer.MaxValue, ErrorMessage:="The Page Size must be positive")>
    <Required>
    Property PageSize As Integer
End Class

Public Class clsPaginationSettingsWithDate
    Inherits clsPaginationSettings

    <Required>
    Property DateFrom As DateTime

End Class