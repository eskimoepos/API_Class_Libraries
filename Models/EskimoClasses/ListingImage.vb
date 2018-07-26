
''' <summary>
''' The Listing Image Class. Supplies an image to be used with the Listings Controller.
''' </summary>
Public Class clsListingImage

    Inherits EskimoBaseClass

    ''' <summary>
    ''' The file name of the image
    ''' </summary>
    ''' <returns></returns>
    Property ImageFileName As String

    ''' <summary>
    ''' An encrypted key that can be used in the api/Listings/ListingImage call to retieve the image. This is an alternative to the api/Images/ImageURL action which requires the auth token to be passed. This can cause the length of the url to become too long for some systems to accept as a valid url.
    ''' </summary>
    ''' <returns></returns>
    Property ImageKey As String

End Class
