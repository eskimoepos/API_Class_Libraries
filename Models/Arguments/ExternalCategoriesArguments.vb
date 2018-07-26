Public Class ExternalCategoriesArguments
    Implements iControllerArguments

    ''' <summary>
    ''' The Category ID
    ''' </summary>
    ''' <returns></returns>
    Property ID As String

    ''' <summary>
    ''' The site that is supplying the category information.
    ''' </summary>
    ''' <returns></returns>
    Property Source As clsListing.ListingTypeEnum

End Class
