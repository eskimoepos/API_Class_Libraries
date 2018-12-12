Imports System.ComponentModel.DataAnnotations
Imports System.Runtime.Serialization
''' <summary>
''' The Order Item Class. This contains information about a singular line within a completed order.
''' </summary>
Public Class clsOrderItem
    Inherits EskimoBaseClass

    ''' <summary>
    ''' Matches the sku_code property from the SKUs Controller. 
    ''' Must be a valid SKU code.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    <StringLength(35)>
    Property sku_code As String

    ''' <summary>
    ''' The quantity being purchased.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Range(1, Int16.MaxValue, ErrorMessage:="A positive quantity must be submitted")>
    Property qty_purchased As Integer

    ''' <summary>
    ''' The price of one of these items AFTER any discounts. 
    ''' So assuming the customer bought 4 of the item priced at £25.00 and then received a £10.00 discount, this unit_price value should be 22.50
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property unit_price As Decimal

    ''' <summary>
    ''' The sum of the discounts applied to all of the items on this line. 
    ''' See notes on unit_price; In the example there, this value would be 10.00
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property line_discount_amount As Decimal

    ''' <summary>
    ''' Optional property that allows for any notes about this item. 
    ''' For example, the item purchased may be a personalised t-shirt and this will contain the name to be printed on the reverse. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property item_note As String

    ''' <summary>
    ''' The description of the product. This is populated when retrieving order information and is not required for inserting new orders.
    ''' </summary>
    ''' <returns></returns>
    Property item_description As String

    ''' <summary>
    ''' The VAT Percentage rate for this product. Not required when inserting orders as the rate associated with the product will be used. This is populated when retrieving an order though.
    ''' </summary>
    ''' <returns></returns>
    Property vat_rate As Decimal?

    ''' <summary>
    ''' Optional. If omitted, the VAT ID assigned to the product will be used. If the goods are being exported outside of the UK for instance, the VAT ID might be different to what is assigned on the product. See api/TaxCodes/All for a list of the possible values
    ''' </summary>
    ''' <returns></returns>
    Property vat_id As Integer?

    Function line_value() As Decimal
        Return Me.unit_price * Me.qty_purchased
    End Function

    Function savings() As Decimal
        Return (Me.line_value + Me.line_discount_amount) - Me.line_value
    End Function

    Sub New()

    End Sub

    Sub New(descr As String)
        Me.item_description = descr
    End Sub
End Class
