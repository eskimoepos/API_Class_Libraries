''' <summary>
''' The Variation Detail Class. eBay may require certain required fields to be completed in order for an item to be listed. This class represents those values.
''' This class is used in the Listings class (to show which variations the product comes in).
''' </summary>
Public Class clsVariationDetail
    Inherits EskimoBaseClass

    ''' <summary>
    ''' The name of the option
    ''' </summary>
    ''' <returns></returns>
    Property OptionName As String

    ''' <summary>
    ''' The value of the option
    ''' </summary>
    ''' <returns></returns>
    Property Value As String

    ''' <summary>
    ''' A collection of images for this variation
    ''' </summary>
    ''' <returns></returns>
    Property VariationImages As IEnumerable(Of clsListingImage)

End Class
