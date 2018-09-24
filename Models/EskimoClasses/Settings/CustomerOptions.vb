Public Class clsCustomerOptions

    Property AutoCustomer As clsTillMenuUnitInfo.OptionTimingEnum = clsTillMenuUnitInfo.OptionTimingEnum.Off
    Property AutoShippingAddress As clsTillMenuUnitInfo.OptionTimingEnum = clsTillMenuUnitInfo.OptionTimingEnum.Off
    Property PostcodeLookupServiceEnabled As Boolean
    Property SearchLimit As Integer = 500
    Property SearchOnlineDefault As Boolean
End Class
