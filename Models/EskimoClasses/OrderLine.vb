Imports System.ComponentModel.DataAnnotations
Imports System.Runtime.Serialization
Imports EskimoClassLibraries.clsSaleItemBase
''' <summary>
''' The Order Item Class. This contains information about a singular line within a completed order.
''' </summary>
Public Class clsOrderItem
    Inherits EskimoBaseClass

    Implements IValidatableObject

    ''' <summary>
    ''' A unique number for each line in the sale. Start at 1 and increment. Optional, unless Kit items are included.
    ''' </summary>
    ''' <returns></returns>
    Property lineID As Integer?

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

    ''' <summary>
    ''' Determines if this order line is part of a package (or kit). If omitted, 5 (Normal item) will be assumed.
    ''' </summary>
    ''' <returns></returns>
    <EnumDataType(GetType(ItemKitTypeEnum))>
    Property kit_product_type As ItemKitTypeEnum = ItemKitTypeEnum.NormalItem

    Function KitSequence() As Long?
        If Me.kit_parent_line IsNot Nothing Then
            Return Me.kit_parent_line
        ElseIf Me.IsKitHeader Then
            Return Me.lineID
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' If this item is a kit (package) component, then this property determines which item in the sale is the kit header
    ''' </summary>
    ''' <returns></returns>
    Property kit_parent_line As Long?

    Function IsKitHeader() As Boolean
        Select Case Me.kit_product_type
            Case ItemKitTypeEnum.FixedHeader, ItemKitTypeEnum.VariableHeader
                Return True
        End Select
        Return False
    End Function

    Function IsKitComponent() As Boolean
        Select Case Me.kit_product_type
            Case ItemKitTypeEnum.FixedComponent, ItemKitTypeEnum.VariableComponent
                Return True
        End Select
        Return False
    End Function

    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim lst As New List(Of ValidationResult)



        Return lst.AsEnumerable
    End Function
End Class
