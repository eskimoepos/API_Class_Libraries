Public Class AddressValidationSummary
    Inherits EskimoBaseClass

    Enum ValidationSummaryTypeEnum
        Address = 1
        Street = 2
        BuildingNumber = 3
    End Enum

    Property ID As String
    Property Description As String
    Property SummaryType As ValidationSummaryTypeEnum
End Class
