Public Class PostedListing
    ''' <summary>
    ''' The Eskimo Listing ID
    ''' </summary>
    ''' <returns></returns>
    Property EskimoListingID As Integer

    ''' <summary>
    ''' The Code eBay or Amazon use to identify the listing
    ''' </summary>
    ''' <returns></returns>
    Property ExternalListingID As String

    ''' <summary>
    ''' The date/time the listed was posted externally.
    ''' </summary>
    ''' <returns></returns>
    Property DateListed As Date
End Class

''' <summary>
''' The array of listings that needs to be updated
''' </summary>
Public Class PostedListings
    Inherits EskimoBaseClass

    ''' <summary>
    ''' The array of listings that needs to be updated
    ''' </summary>
    ''' <returns></returns>
    Property Listings As New List(Of PostedListing)
End Class