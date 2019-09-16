Imports System.ComponentModel.DataAnnotations

Public Class clsTillMenuItem

    Inherits EskimoBaseClass

    ''' <summary>
    ''' The Name of the item... i.e. Guiness
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property Name As String

    ''' <summary>
    ''' The unit prices of the product i.e. £4.50. There will be a maximum of 10 price levels. Price level 1 is the default.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property UnitPrices As IEnumerable(Of clsPrice)

    ''' <summary>
    ''' The PLU number of the product. Could be used to enter or scan the product, rather than choose from the menu system.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(35)>
    <Required>
    Property PLU As String

    ''' <summary>
    ''' A list of any questions/customisations for the item.
    ''' </summary>
    ''' <returns></returns>
    Property FollowOns As List(Of clsTillMenuChoice)

    ''' <summary>
    ''' If true, the client should not use the price provided, but rather it should prompt the user for the price.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property IsOpenPriced As Boolean = False

    ''' <summary>
    ''' If true, the client should not use the product description provided, but rather it should prompt the user for the description.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property IsOpenDescription As Boolean = False

    ''' <summary>
    ''' This is the Eskimo Image ID assigned to the menu item. Can use api/Images/ImageData/{id} to obtain the image
    ''' </summary>
    ''' <returns></returns>
    Property ImageID As Integer?

    ''' <summary>
    ''' See api/TaxCodes/All
    ''' </summary>
    ''' <returns></returns>
    Property TaxID As Integer
    Property ProductDescription As String

    Property ColourName As String
    Property ColourValue As String
    Property Size As String
    Property StockWarnLevel As Integer?
    Property StockLevel As Integer
    Property NoDiscountAllowed As Boolean

End Class
