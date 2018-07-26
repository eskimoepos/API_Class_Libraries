Public Class ListingsArguments
    Implements iControllerArguments

    Enum ListingFilterEnum
        ''' <summary>
        ''' All listings
        ''' </summary>
        AllListings = 0

        ''' <summary>
        ''' Only the eBay Listings
        ''' </summary>
        eBayOnly = 1

        ''' <summary>
        ''' Only the Amazon Listings
        ''' </summary>
        AmazonOnly = 2
    End Enum

    ''' <summary>
    ''' Specifies whether you want to retieve listings of all types, or only those for a singular type.
    ''' </summary>
    ''' <returns></returns>
    Property ListingFIlter As ListingFilterEnum = ListingFilterEnum.AllListings

End Class
