Public Class clsProductOptions

    Enum TillScreenEnum
        ProductInformation = 1
        ProductMenu = 2
    End Enum
    Property SearchLimit As Integer = 500
    Property AllowMultiSelect As Boolean = True
    Property DefaultTillScreen As TillScreenEnum
    Property SearchOnlineDefault As Boolean
    Property ShowLowStockWarnings As Boolean = True
End Class
