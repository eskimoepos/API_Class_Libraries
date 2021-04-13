Imports System.ComponentModel.DataAnnotations

''' <summary>
''' The Image Link Class. This class joins an Image to an Object. The type of that object is specified in the ImageLinkType property.
''' </summary>
Public Class clsImageLink
    Inherits clsImageLinkBase

    ''' <summary>
    ''' The AlphaNumeric Web ID of the Image Link
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property WebImageID As String

    ''' <summary>
    ''' The alphanumeric Eskimo ID of the image link. This is made up of the Object ID (below) and the Eskimo Link ID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property EskimoLinkID As String

    ''' <summary>
    ''' The Alphanumeric Web ID of the image link
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property WebImageLinkID As String

    ''' <summary>
    ''' The SKU (if the ImageLinkType is 100)
    ''' </summary>
    ''' <returns></returns>
    Property sku_code As String

End Class


Public Class clsImageLinkInsert
    Inherits clsImageLinkBase

End Class

Public Class clsImageLinkBase
    Inherits EskimoBaseClass

    ''' <summary>
    ''' The numeric Eskimo ID of the image
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property EskimoImageID As Integer


    ''' <summary>
    ''' The Eskimo ID of the object this links so. For instance, if it is a SKU image, it will be the sku_code from the SKUs controller; if it is a Category image type, then it will be the Eskimo_Category_ID from the Categories controller etc.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property ObjectID As String

    <Required>
    Property ImageLinkType As ImageLinkTypeEnum

    ''' <summary>
    ''' If a product has more than one image, it will have three entries in the images controller, the first (main) one will have an Index of 1 and the subsequent ones will be 2 and 3.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property Index As Integer

    Enum ImageLinkTypeEnum
        ''' <summary>
        ''' An image of a SKU
        ''' </summary>
        ''' <remarks></remarks>
        SKU = 100
        ''' <summary>
        ''' A Style Reference Product (Containing different colour and size combinations)
        ''' </summary>
        ''' <remarks></remarks>
        StyleRef = 150
        ''' <summary>
        ''' A category thumbnail image
        ''' </summary>
        ''' <remarks></remarks>
        Category = 200
        ''' <summary>
        ''' A category banner image (usually larger than the Category images)
        ''' </summary>
        ''' <remarks></remarks>
        Banner = 250
        ''' <summary>
        ''' A trade customer logo or emblem
        ''' </summary>
        ''' <remarks></remarks>
        TradeCustomerLogo = 300
        ''' <summary>
        ''' The shop font of a customer 
        ''' </summary>
        ''' <remarks></remarks>
        TradeCustomerPremises = 350
        ''' <summary>
        ''' The logo of a product brand
        ''' </summary>
        ''' <remarks></remarks>
        Brand = 400
    End Enum

End Class
