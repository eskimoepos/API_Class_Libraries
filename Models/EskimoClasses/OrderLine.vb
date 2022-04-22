Imports System.ComponentModel.DataAnnotations
Imports System.Runtime.Serialization
Imports EskimoClassLibraries.clsSaleItemBase


Public Interface iOrderItem

    Property qty_purchased As Integer

    Property unit_price As Decimal

    Property lineID As Integer?

End Interface

Public Class clsOrderItemExt
    Inherits clsOrderItemBase

    ''' <summary>
    ''' How many of the ordered quantity have been shipped from the Eskimo system.
    ''' </summary>
    ''' <returns></returns>
    Property qty_shipped As Integer

    ''' <summary>
    ''' How many of the ordered quantity have been refunded from the Eskimo system.
    ''' </summary>
    ''' <returns></returns>
    Property qty_refunded As Integer

    ''' <summary>
    ''' The database id for this item
    ''' </summary>
    ''' <returns></returns>
    Property id As String

    Property status As OrderStatusEnum

    Enum OrderStatusEnum

        ''' <summary>
        ''' When an item is first inserted
        ''' </summary>
        InitialStatus = 0

        ''' <summary>
        ''' This item has not yet been ordered from the supplier
        ''' </summary>
        NotOrdered = 3

        ''' <summary>
        ''' Item has been ordered from the supplier , but it hasn't arrived yet
        ''' </summary>
        NotReceived = 4

        ''' <summary>
        ''' Item is ready for dispatch/customer collection
        ''' </summary>
        NotCollected = 5

        ''' <summary>
        ''' Item has been dispatched/collected
        ''' </summary>
        Collected = 6

        ''' <summary>
        ''' Item is no longer required.
        ''' </summary>
        NotFulfilled = 7

    End Enum

    Sub New()

    End Sub

    Sub New(descr As String)
        Me.item_description = descr
    End Sub

End Class

Public Class clsOrderItem
    Inherits clsOrderItemBase

    Sub New()

    End Sub

    Sub New(descr As String)
        Me.item_description = descr
    End Sub

End Class

''' <summary>
''' The Order Item Class. This contains information about a singular line within a completed order.
''' </summary>
Public MustInherit Class clsOrderItemBase

    Implements IValidatableObject, iOrderItem

    ''' <summary>
    ''' A unique number for each line in the sale. Start at 1 and increment. Optional, unless Kit items are included.
    ''' </summary>
    ''' <returns></returns>
    Property lineID As Integer? Implements iOrderItem.lineID

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
    Property qty_purchased As Integer Implements iOrderItem.qty_purchased

    ''' <summary>
    ''' The price of one of these items AFTER any discounts. 
    ''' So assuming the customer bought 4 of the item priced at £25.00 and then received a £10.00 discount, this unit_price value should be 22.50
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property unit_price As Decimal Implements iOrderItem.unit_price

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



    Function savings() As Decimal
        Return (Me.line_value + Me.line_discount_amount) - Me.line_value
    End Function


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
