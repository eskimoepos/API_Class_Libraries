Imports System.ComponentModel.DataAnnotations

''' <summary>
''' The Category > Product Class. Links Products and Categories together.
''' </summary>
Public Class clsCategoryProduct

    Inherits EskimoBaseClass

    ''' <summary>
    ''' The Eskimo Identifier of the Product
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property eskimo_product_identifier As String

    ''' <summary>
    ''' The Eskimo Category ID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property eskimo_category_id As String

    ''' <summary>
    ''' The Primary Key of the Category as used by the website. These are set using the UpdateCartIDs POST action in the Category controller.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(200)>
    Property web_category_id As String

    ''' <summary>
    ''' The Primary Key of the Product as used by the website. These are set using the UpdateCartIDs POST action in the Products controller.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(200)>
    Property web_product_id As String

End Class
