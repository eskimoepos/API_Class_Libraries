''' <summary>
''' Eskimo Product Category Class. Contains information about the categories that products fall into.
''' </summary>
''' <remarks></remarks>
Public Class clsCategory

    Inherits EskimoBaseClass

    'Private _orderByValue As Long
    'Private _shortDescription As String
    'Private _longDescription As String
    'Private _parentID As Long
    'Private _categoryID As Long

    Public Property Eskimo_Category_ID() As String

    ''' <summary>
    ''' The Eskimo ID of the parent Category. Returns (null) if a top-level category.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParentID() As String

    Public Property ShortDescription() As String
    
    Public Property LongDescription() As String
   
    ''' <summary>
    ''' An integer value which can be used to specify the order the categories are displayed in
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OrderByValue() As Long

    ''' <summary>
    ''' This is the Primary Key that the website is using for this category. Call the UpdateCartIDs method to set these values
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Web_ID As String

    ''' <summary>
    ''' The number of products linked to this category
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Product_Count As Integer

    ''' <summary>
    ''' The Sales Channel (Website) that the category is linked to. See api/Sales/Channels
    ''' </summary>
    ''' <returns></returns>
    Public Property Channel_ID As Integer

    ''' <summary>
    ''' A url category path. 
    ''' </summary>
    ''' <returns></returns>
    Public Property URL_Path As String

    ''' <summary>
    ''' A friendly-url representation of the category name
    ''' </summary>
    ''' <returns></returns>
    Public Property URL_Path_Component As String

    ''' <summary>
    ''' The current status of category
    ''' </summary>
    ''' <returns></returns>
    Public Property Status As CategoryStatusEnum

    Enum CategoryStatusEnum
        ''' <summary>
        ''' Should be treated as Inactive or Disabled in the cart
        ''' </summary>
        Disabled = 1

        ''' <summary>
        ''' Active category with product underneath it
        ''' </summary>
        Active = 2

        ''' <summary>
        ''' Some carts allow for Hidden categories, which function the same as an Active category when the url is entered manually, but the existance of the category will not be publicized in the nav for users to 'find'.
        ''' </summary>
        Hidden = 3

    End Enum

End Class
