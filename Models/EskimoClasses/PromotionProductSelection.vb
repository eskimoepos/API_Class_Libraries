Public Class clsPromotionProductSelection
    Implements ICloneable

    ''' <summary>
    ''' An ID that groups the choices together. 
    ''' </summary>
    ''' <returns></returns>
    Property CollectionID As Integer

    ''' <summary>
    ''' The number of that product that must be present.
    ''' </summary>
    ''' <returns></returns>
    Property Qty As Integer

    ''' <summary>
    ''' Every product in Eskimo belongs to a Group (like a category). This is the ID of that Group. Only populated if the Join Type is 1.
    ''' </summary>
    ''' <returns></returns>
    Property GroupID As Integer?

    ''' <summary>
    ''' Every product in Eskimo belongs to a Department (like a category) that in turn, sits underneath a Group. This is the ID of that Department. Only populated if the Join Type is 2.
    ''' </summary>
    ''' <returns></returns>
    Property DepartmentID As Integer?

    ''' <summary>
    ''' Several products in Eskimo can be tied together their Style Reference. For example a jumper that comes in multiple colours and sizes, would have SKU for each variation, but would share the same Style Reference. Only populated if the Join Type is 3.
    ''' </summary>
    ''' <returns></returns>
    Property StyleReference As String

    ''' <summary>
    ''' The PLU (or SKU) of the product. Only populated if the Join Type is 4.
    ''' </summary>
    ''' <returns></returns>
    Property PLU As String

    ''' <summary>
    ''' Every product in Eskimo is linked to a Product Type. This is the ID and is only populated if the Join Type is 5
    ''' </summary>
    ''' <returns></returns>
    Property ProductType As Integer?

    ''' <summary>
    ''' The method to use to identify the products in question.
    ''' </summary>
    ''' <returns></returns>
    Property JoinType As JoinTypeEnum

    ''' <summary>
    ''' A human-readable description of the product filter, specified by the person who setup the promotion.
    ''' </summary>
    ''' <returns></returns>
    Property FriendlyTitle As String
    Enum JoinTypeEnum
        Group = 1
        Department = 2
        StyleReference = 3
        PLU = 4
        ProductType = 5
    End Enum

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class

Public Class clsPromotionProductSelections

    ''' <summary>
    ''' A collection of product grouping choices. Only one of the entries must be met for the selection to pass. 
    ''' </summary>
    ''' <returns></returns>
    Property Choices As New List(Of clsPromotionProductSelection)

    ''' <summary>
    ''' An iteration ID. Matches the CollectionID in the Choises values.
    ''' </summary>
    ''' <returns></returns>
    Property CollectionID As Integer

End Class