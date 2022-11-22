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
    ''' The position the product should appear in on a category page. (Irrelevant if ordering by price or alphabetical, but applicable when ordering by position.)
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Public Property position As Integer

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
    ''' An additional key/value pair field for this product. The retailer can use this for whatever purpose they need.
    ''' </summary>
    ''' <returns></returns>
    Public Property addfield04 As KeyValuePair(Of Integer, String)?

    ''' <summary>
    ''' An additional key/value pair field for this product. The retailer can use this for whatever purpose they need.
    ''' </summary>
    ''' <returns></returns>
    Public Property addfield05 As KeyValuePair(Of Integer, String)?

    ''' <summary>
    ''' An additional boolean field for this product. The retailer can use this for whatever purpose they need.
    ''' </summary>
    ''' <returns></returns>
    Public Property addfield06 As Boolean

    ''' <summary>
    ''' The Eskimo ID of the company that supplies the product. 
    ''' </summary>
    ''' <returns></returns>
    Public Property supplier_id As String

    ''' <summary>
    ''' The Company Name of the business that supplies the product. 
    ''' </summary>
    ''' <returns></returns>
    Public Property supplier_name As String

    ''' <summary>
    ''' States whether this product is a package header. If it is, the eskimo_identifier of this product can be passed to the call for details of the package.
    ''' </summary>
    ''' <returns></returns>
    Public Property is_package As Boolean

    ''' <summary>
    ''' Although the field label is called Colour, customers can choose to rename this to something else. This field denotes what should be displayed in the dropdown label
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Public Property colour_terminology As String

    ''' <summary>
    ''' Although the field label is called Size, customers can choose to rename this to something else. This field denotes what should be displayed in the dropdown label
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Public Property size_terminology As String

    ''' <summary>
    ''' If true, this indicates that the product is a package component, but should not be sold separately.
    ''' </summary>
    ''' <returns></returns>
    Public Property package_component_only As Boolean

    ''' <summary>
    ''' Determines whether a colour drop-down should be utilitised on the product page or not.
    ''' </summary>
    ''' <returns></returns>
    Public Property use_colour_option As Boolean

    ''' <summary>
    ''' Determines whether a size drop-down should be utilitised on the product page or not.
    ''' </summary>
    ''' <returns></returns>
    Public Property use_size_option As Boolean

End Class
