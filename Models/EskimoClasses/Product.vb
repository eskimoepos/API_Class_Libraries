Imports System.ComponentModel.DataAnnotations

''' <summary>
''' A Web-enabled Product (one that has been marked to appear on an eCommerce site). Each product can have multiple SKUs. Use the SKUs Controller to access the pricing and stock information.
''' </summary>
Public Class clsProduct
    Inherits EskimoBaseClass

    Public Overrides Function ToString() As String

        If Me.eskimo_identifier Is Nothing Then
            Return ""
        Else
            Return Me.eskimo_identifier
        End If

    End Function

    ''' <summary>
    ''' A unique Eskimo-generated key
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Key>
    <Required>
    Public Property eskimo_identifier As String

    ''' <summary>
    ''' The title of the product
    ''' </summary>
    ''' <value>Samsung UE32J5100AK - 32" LED TV - 1080p</value>
    ''' <returns>returns from here</returns>
    ''' <remarks>remarks from here</remarks>
    <StringLength(255)>
    Public Property title As String

    Public Property short_description As String

    Public Property long_description As String

    <StringLength(255)>
    Public Property meta_keywords As String

    Public Property meta_description As String

    Public Property search_words As String

    <StringLength(255)>
    Public Property page_title As String

    ''' <summary>
    ''' The Eskimo Style Reference code. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(12)>
    Public Property style_reference As String

    ''' <summary>
    ''' When the product was created in the Eskimo system
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Public Property date_created As DateTime

    ''' <summary>
    ''' When the product was last modified in the Eskimo system
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Public Property last_updated As DateTime

    ''' <summary>
    ''' This is the Primary Key that the website is using for this product. Call the UpdateCartIDs method to set these values
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property web_id As String

    ''' <summary>
    ''' This is the Eskimo Category ID for the default/main category linked to this product
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property eskimo_category_id As String

    ''' <summary>
    ''' This is the Web Category ID for the default/main category linked to this product. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property web_category_id As String
    ''' <summary>
    ''' The is the lowest price the product comes in. If there are multiple colour and size variations, some of the larger sizes may cost more. Consult the SKUs controller to find exact pricing on each SKU underneath a product.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property from_price As Decimal

    ''' <summary>
    ''' An additional field for this product. The retailer can use this for whatever purpose they need.
    ''' </summary>
    ''' <returns></returns>
    Public Property addfield04 As Integer

End Class
