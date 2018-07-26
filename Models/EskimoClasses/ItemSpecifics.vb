''' <summary>
''' The Item Specifics Class. eBay may require certain required fields to be completed in order for an item to be listed. This class represents those values.
''' This class is used from within the External Categories class (to populate the Eskimo database with all possible values)
''' </summary>
Public Class clsItemSpecifics
    Inherits clsItemSpecificsBasic

    Enum SelectionModeEnum

        ''' <summary>
        ''' Indicates the seller must use eBay's recommended item specifics, and cannot use their own custom item specifics when creating a listing with Add/Revise/Relist calls.
        ''' </summary>
        SelectionOnly = 1

        ''' <summary>
        ''' Indicates the seller can create their own custom item specifics or they can use eBay recommended item specifics for the category when creating a listing with Add/Revise/Relist calls.
        ''' </summary>
        FreeText = 2

        ''' <summary>
        ''' 	Indicates eBay recommended and required item specifics will be pre-filled by eBay if a product ID is provided in the Add/Revise/Relist call.
        ''' </summary>
        PreFilled = 3
    End Enum

    Enum ValueTypeEnum
        [Date] = 1
        [Decimal] = 2
        EAN = 3
        ISBN = 4
        [Integer] = 5
        Text = 6
        UPC = 7
    End Enum

    ''' <summary>
    ''' The minimum number of values that can be chosen for this property. Zero means that it is optional.
    ''' </summary>
    ''' <returns></returns>
    Property MinSelected As Integer

    ''' <summary>
    ''' The maximum number of values that can be chosen for this property.
    ''' </summary>
    ''' <returns></returns>
    Property MaxSelected As Integer

    ''' <summary>
    ''' Controls whether you can specify your own name and value in listing requests, or if you need to use a name and/or value that eBay has defined.
    ''' </summary>
    ''' <returns></returns>
    Property SelectionMode As SelectionModeEnum

    ''' <summary>
    ''' The data type (e.g., date) that eBay expects the value to adhere to in listing requests. Only returned if the data type is not Text. 
    ''' </summary>
    ''' <returns></returns>
    Property ValueType As ValueType

End Class
