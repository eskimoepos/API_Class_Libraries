Imports System.ComponentModel.DataAnnotations

Public Class clsCustomerOptions

    Property AutoCustomer As clsTillMenuUnitInfo.OptionTimingEnum = clsTillMenuUnitInfo.OptionTimingEnum.Off
    Property AutoShippingAddress As clsTillMenuUnitInfo.OptionTimingEnum = clsTillMenuUnitInfo.OptionTimingEnum.Off
    Property PostcodeLookupServiceEnabled As Boolean
    Property SearchLimit As Integer = 500
    Property SearchOnlineDefault As Boolean
    Property DefaultSourceCodeID As Integer?
    Property DefaultPriceLevel As Integer
    <StringLength(2, ErrorMessage:="Country code must be 2 digits in length.", MinimumLength:=2)>
    <Required>
    Property DefaultCountryCode As String
End Class
