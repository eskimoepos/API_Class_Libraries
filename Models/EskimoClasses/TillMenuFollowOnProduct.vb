Imports System.ComponentModel.DataAnnotations

Public Class clsTillMenuFollowOnProduct
    <Required>
    Property MasterPLU As String
    Property Items As New List(Of clsTillMenuFollowOnProductDetail)
End Class

Public Class clsTillMenuFollowOnProductDetail
    Property DetailID As Integer
    Enum GroupingTypeEnum
        NotPartOfGroup = 1
        PartOfGroupDefault = 2
        PartOfGroupNotDefault = 3
    End Enum
    Property PLU As String
    Property Description As String
    Property OrderBy As Integer
    Property Qty As Integer
    Property Notes As String
    Property Grouping As GroupingTypeEnum
    Property Price As Decimal?
    Property TaxID As Integer
    Property ColourName As String
    Property IsOpenPriced As Boolean
    Property StockLevel As Integer
    Property StockWarnLevel As Integer?
    Property Size As String
    Property NoDiscountAllowed As Boolean
End Class