Public Class clsPackageChoiceGroup

    ''' <summary>
    ''' An order by for this 'question'
    ''' </summary>
    ''' <returns></returns>
    Property choice_index As Integer

    ''' <summary>
    ''' Optional. A prompt or description for the choices that follow
    ''' </summary>
    ''' <returns></returns>
    Property choice_description As String

    ''' <summary>
    ''' An array of package choices for this same index.
    ''' </summary>
    ''' <returns></returns>
    Property choices As New List(Of clsPackageChoice)

End Class

Public Class clsPackageSKU
    Inherits clsSKU

    Property Qty As Integer
    Property OrderBy As Integer

End Class

Public Class clsPackageChoice
    ''' <summary>
    ''' Package choice ID
    ''' </summary>
    ''' <returns></returns>
    Property id As Integer
    ''' <summary>
    ''' The text that can be displayed next to the product
    ''' </summary>
    ''' <returns></returns>
    Property label As String
    ''' <summary>
    ''' The product identifier of this product. Will link to api/Products/All
    ''' </summary>
    ''' <returns></returns>
    Property product_identifier As String
    ''' <summary>
    ''' Optional. The order in which the products should be displayed
    ''' </summary>
    ''' <returns></returns>
    Property order_by As Integer

    ''' <summary>
    ''' A list of the SKUs that are underneath the product. This will not necessarily be all of the SKUs that this product contains. For example, the retailer may only choose to exclude larger, more expensive sizes from this package deal.
    ''' </summary>
    ''' <returns></returns>
    Property skus As New List(Of clsPackageSKU)

End Class

Public Class clsPackage

    ''' <summary>
    ''' This is the information about the package itself. This matches that found in the api/Products/All call
    ''' </summary>
    ''' <returns></returns>
    Property header_product As clsProduct

    ''' <summary>
    ''' An array of choices that can be made by the purchaser. Where only one option is supplied, there is no choice between products - only between SKUs (i.e. the colour/size combination that they would like.)
    ''' </summary>
    ''' <returns></returns>
    Property choice_groups As New List(Of clsPackageChoiceGroup)

End Class