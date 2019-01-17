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
    Property OrderBy As Integer
    Property Qty As Integer
    Property Notes As String
    Property Grouping As GroupingTypeEnum
    Property Price As Decimal?
End Class