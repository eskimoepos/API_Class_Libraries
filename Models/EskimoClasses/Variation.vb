Public Class clsVariation
    Inherits EskimoBaseClass

    ''' <summary>
    ''' The Eskimo SKU for this variation
    ''' </summary>
    ''' <returns></returns>
    Property SKU As String

    ''' <summary>
    ''' The price of the SKU
    ''' </summary>
    ''' <returns></returns>
    Property Price As Decimal

    ''' <summary>
    ''' The EAN code of the item
    ''' </summary>
    ''' <returns></returns>
    Property EANCode As String

    ''' <summary>
    ''' The quantity on hand for this SKU
    ''' </summary>
    ''' <returns></returns>
    Property QtyOffered As Integer

    ''' <summary>
    ''' A collection of the attributes for this SKU
    ''' </summary>
    ''' <returns></returns>
    Property Attributes As clsVariationDetail()


End Class
