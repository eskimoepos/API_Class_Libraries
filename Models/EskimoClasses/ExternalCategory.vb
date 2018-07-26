Imports System.ComponentModel.DataAnnotations
''' <summary>
''' The External Category Class. This class contains information about a third-party provider's categories; for instance eBay or Amazon. These can be imported into the Eskimo system, enabling the retailer to create listings. These can then be exported via the Listings controller.
''' </summary>
Public Class clsExternalCategory
    Inherits EskimoBaseClass


    ''' <summary>
    ''' The unique identifier of the category
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(50)>
    Property CategoryID As String

    ''' <summary>
    ''' Top level categories will be 1, then beneath these, child categories will be 2, 3 and so on.
    ''' </summary>
    ''' <returns></returns>
    Property CategoryLevel As Integer

    ''' <summary>
    ''' The unique identifier of the parent category. Pass NULL for top-level categories.
    ''' </summary>
    ''' <returns></returns>
    Property CategoryParentID As String

    ''' <summary>
    ''' The site that the category is used on
    ''' </summary>
    ''' <returns></returns>
    Property CategorySource As clsListing.ListingTypeEnum
    ''' <summary>
    ''' The name of the Category
    ''' </summary>
    ''' <returns></returns>
    Property CategoryName As String
    ''' <summary>
    ''' A collection of key-value pairs allowing the list of products returned to be filtered efficiently. For example, if the category is a Jumpers, eBay may have a Property called Material, with possible values of Sheep Wool, Cashmere, Cotton and Linen.
    ''' </summary>
    ''' <returns></returns>
    Property ItemSpecifics As New List(Of clsItemSpecifics)

    Property LeafCategory As Boolean

    ''' <summary>
    ''' Optional. Further ID for the category, if required.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(200)>
    Property AdditionalIdentifier As String

    Sub New()

    End Sub

    Sub New(CatID As String, Source As clsListing.ListingTypeEnum, Name As String, Specifics As List(Of clsItemSpecifics))
        Me.CategoryID = CatID
        Me.CategorySource = Source
        Me.CategoryName = Name
        Me.ItemSpecifics = Specifics
    End Sub
End Class
