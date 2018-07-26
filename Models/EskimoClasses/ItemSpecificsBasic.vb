''' <summary>
''' The Item Specifics Class (Basic). eBay may require certain required fields to be completed in order for an item to be listed. This class represents those values.
''' This class is used in the Listings class (to show which values have been chosen).
''' </summary>
Public Class clsItemSpecificsBasic
    Inherits EskimoBaseClass

    ''' <summary>
    ''' The name of the property
    ''' </summary>
    ''' <returns></returns>
    Property SpecificsName As String

    ''' <summary>
    ''' The values that are avilable to choose from.
    ''' </summary>
    ''' <returns></returns>
    Property Values As String()

End Class
