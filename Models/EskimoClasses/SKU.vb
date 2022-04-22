Imports System.ComponentModel.DataAnnotations

''' <summary>
''' The SKUs Class. The SKUs fall underneath the Products. Use the Product controller to access the product information.
''' </summary>
Public Class clsSKU
    Inherits EskimoBaseClass

    Public Overrides Function ToString() As String
        If Me.sku_code Is Nothing Then
            Return ""
        Else
            Return Me.sku_code
        End If
    End Function

    <Required>
    Public Property eskimo_product_identifier As String

    ''' <summary>
    ''' Eskimo Customer ID - See the Customer Controller. If this product is specifically for a trade customer,  then this property denotes which customer it is for. If it is a generic product then this will be zero-length string.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(10, ErrorMessage:=clsCustomer.CustomerLengthMsg, MinimumLength:=10)>
    <RegularExpression(clsCustomer.CustomerIDFormat)>
    <ValidCustomer>
    Public Property trade_customer_id As String

    ''' <summary>
    ''' This is the barcode or PLU number. In a retail shop, this will be the code that the operator will scan into the till at POS. This can either be a code that exclusively represents that product worldwide, or it could be a unique code for that retailer only - one that they have assigned to the product.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    <StringLength(35)>
    Public Property sku_code As String

    ''' <summary>
    ''' Optional. An additional barcode. Supplier's EAN perhaps.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(35)>
    Public Property additional_sku_code As String


    ''' <summary>
    ''' On top of the sku code, Eskimo uses a Style Reference code to group SKUs together of a similar type. For example, you may have a jumper that comes in 3 colours and 3 sizes. All 9 of the SKUs will share the same Style Reference code (JUM-01 for example) but they will also have unique sku codes. This field should have the same value as the style_reference property on the Products controller for the same product.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(12)>
    Public Property Style_Reference As String

    ''' <summary>
    ''' The Eskimo Colour code. (i.e. BK)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(6)>
    Public Property ColourID As String

    ''' <summary>
    ''' The name of the colour (i.e. Black)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(50)>
    Public Property ColourName As String

    ''' <summary>
    ''' The size of the product (i.e. Small or 23")
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(50)>
    Public Property Size As String

    ''' <summary>
    ''' The price that the retailer pays to obtain the product 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Public Property CostPrice As Decimal

    ''' <summary>
    ''' Optional. The Supplier's Recommended Retail Selling price of the item. Where this is higher than the 'Sell Price', a 'saving' can be advertised to the end-user.
    ''' </summary>
    ''' <returns></returns>
    Public Property RRP As Decimal?

    ''' <summary>
    ''' The sell price to be used on the website
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Public Property SellPrice As Decimal

    ''' <summary>
    ''' A secondary sell price which can sometimes be used on the website, usually as a trade price
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Public Property SellPrice2 As Decimal

    ''' <summary>
    ''' The Physical amount of stock the retailer has for this item
    ''' </summary>
    ''' <returns></returns>
    Public Property PhysicalStock As Integer

    ''' <summary>
    ''' Customer demand for this item. Orders that customer's have placed which are yet be dispatched to them.
    ''' </summary>
    ''' <returns></returns>
    Public Property Demand As Integer

    ''' <summary>
    ''' The quantity of items the retailer has on hand to sell in the current shop. Free stock. (Physical Stock minus Demand)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Public Property StockAmount As Integer

    ''' <summary>
    ''' The Eskimo Tax Code ID. Links to the TaxCodes controller.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Public Property TaxCodeID As Integer

    ''' <summary>
    ''' If this product is personalisable (i.e. printed t-shirts or engraved trophies) then this text denotes the prompt to the purchaser (i.e. Please enter the name to be engraved.)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(50)>
    Public Property PersonalisationPrompt As String

    ''' <summary>
    ''' Some products have the option of being personalised for a extra fee. This field denotes that fee.
    ''' </summary>
    ''' <returns></returns>
    Public Property PersonalisationSurCharge As Decimal

    ''' <summary>
    ''' The order in which these should be displayed in the GUI to the end user
    ''' </summary>
    ''' <returns></returns>
    Public Property Position As Integer

    ''' <summary>
    ''' This is the Primary Key that the website is using for this SKU. Note this is unique per product - so they same SKU may be in two different products and will therefore have a different Web ID assigned. Call the UpdateCartIDs method to set these values
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property web_id As String

    Enum OutOfStockBehaviourEnum
        ''' <summary>
        ''' If the product is out of stock, the customer cannot buy this product
        ''' </summary>
        NoPurchaseAllowed = 1

        ''' <summary>
        ''' If the product is out of stock, the customer will be allowed to buy the product, but will also receive a warning - perhaps about the delivery delay
        ''' </summary>
        AllowPurchaseWithWarning = 2

        ''' <summary>
        ''' Treat this product like it is in stock. Allow the customer to purchase it and do not give any indication about it's unavailability
        ''' </summary>
        AllowPurchase = 3
    End Enum

    ''' <summary>
    ''' Specified the desired behaviour when the product is out of stock
    ''' </summary>
    ''' <returns></returns>
    Public Property OutOfStockBehaviour As OutOfStockBehaviourEnum = OutOfStockBehaviourEnum.NoPurchaseAllowed

    ''' <summary>
    ''' The value of the weight of this SKU. 
    ''' </summary>
    ''' <returns></returns>
    Public Property WeightValue As Decimal

    ''' <summary>
    ''' The weight unit. For example kg, lbs, grams. See GET api/MeasureUnits/All
    ''' </summary>
    ''' <returns></returns>
    Public Property WeightUnit As Integer

    ''' <summary>
    ''' The Id of the Brand
    ''' </summary>
    ''' <returns></returns>
    Public Property BrandId As Integer?

    ''' <summary>
    ''' The name of the brand if applicable (i.e. Nike, Adidas)
    ''' </summary>
    ''' <returns></returns>
    Public Property BrandName As String

    ''' <summary>
    ''' Controls whether the SKU should be sold as a normal SKU, or only be used within a Product Package/Kit
    ''' </summary>
    ''' <returns></returns>
    Public Property PackageStatus As PackageStatusEnum = PackageStatusEnum.NormalOrPackageComponent

    Public Enum PackageStatusEnum

        ''' <summary>
        ''' Item is sellable and in addition, may or may not be, a package component. 
        ''' </summary>
        NormalOrPackageComponent = 0

        ''' <summary>
        ''' Item is a package Header
        ''' </summary>
        IsPackageHeader = 1

        ''' <summary>
        ''' Item is only a package component and should not be sellable outside of a package.
        ''' </summary>
        PackageComponentOnly = 2
    End Enum

    Public Property CustomAttributeLinks As List(Of clsSKUAttributeLink)

End Class

