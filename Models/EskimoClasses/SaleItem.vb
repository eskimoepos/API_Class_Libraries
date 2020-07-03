Imports System.ComponentModel.DataAnnotations
Imports System.Runtime.InteropServices

Public Class clsSaleItemBase

    Enum CustomerActionEnum

        ''' <summary>
        ''' The customer has taken this item. Nothing further to action.
        ''' </summary>
        NoCustomerAction = -1

        ''' <summary>
        ''' There is not enough stock to fulfil this item. The customer has placed an order for it. They will come back in to collect when available.
        ''' </summary>
        CustomerOrderItem = 0

        'CustomerSale = 1

        ''' <summary>
        ''' Item has been ordered via a website and needs to be either collected or dispatched.
        ''' </summary>
        WebSalesItem = 2

        ''' <summary>
        ''' This is for items that will be fulfilled from a different location (perhaps a warehouse)
        ''' </summary>
        MailOrderItem = 3

        ''' <summary>
        ''' Order has been generated and entered via eBay.
        ''' </summary>
        eBayItem = 4

        ''' <summary>
        ''' Order has been generated and entered via Amazon. This is an FBM order. FBA orders come in as No Customer Action as there is no dispatching to perform on these.
        ''' </summary>
        AmazonItem = 5

        '''' <summary>
        '''' There is enough stock of this item but the customer might not have actually come into the shop. This is used to reserve the item for the customer until such time as they do.
        '''' </summary>
        'ReserveItem = 6

        '''' <summary>
        '''' This is for a product that needs to have something done to it before the customer can return to collect it. i.e. Dry Cleaning, Key Cutting, Embroidery
        '''' </summary>
        'CustomisationItem = 7

    End Enum

    ''' <summary>
    ''' Kits refer to a product that, when sold, deduct stock for a bill of materials. These kits fall into two categories, Static - where the components are fixed and Variable - where the components could vary within a range. An example of the variable kit might be a child's school uniform kit (bundle). The child could be male or female and different sizes so the components might be a skirt or trousers, shirt or blouse etc.
    ''' </summary>
    Enum ItemKitTypeEnum

        ''' <summary>
        ''' The Header PLU of a fixed kit. This is the one that will be scanned into the till
        ''' </summary>
        FixedHeader = 1

        ''' <summary>
        ''' The Header PLU of a variable kit. This is the one that will be scanned into the till
        ''' </summary>
        VariableHeader = 2

        ''' <summary>
        ''' This is a component PLU of a fixed kit. The operator does need to see this in the front-end necessarily, but the stock for this item will be reduced as the kit it sold.
        ''' </summary>
        FixedComponent = 3

        ''' <summary>
        ''' This is a component PLU of a variable kit. The operator will need to choose which components they want to buy when the header PLU is being sold.
        ''' </summary>
        VariableComponent = 4

        ''' <summary>
        ''' This is a PLU being sold outside of the scope of a kit. It is possible for this PLU to be a component of a kit, but in this instance, it is being sold on its own.
        ''' </summary>
        NormalItem = 5
    End Enum

    ''' <summary>
    ''' PLU number of the product 
    ''' </summary>
    ''' <returns></returns>
    <StringLength(35)>
    <Required>
    Property PLU As String

    ''' <summary>
    ''' The quantity being ordered
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property Qty As Integer = 1

    ''' <summary>
    ''' Readonly. The UnitPrice of the product after discounts
    ''' </summary>
    ''' <returns></returns>
    ReadOnly Property UnitPrice As Decimal
        Get
            If Me.Qty = 0 Then Throw New Exception("Qty cannot be zero")
            Dim decReturn As Decimal = Me.LinePrice / Me.Qty
            If decReturn < 0 Then decReturn = decReturn * -1 'unit price must always be positive
            Return decReturn
        End Get
    End Property

    Function OriginalUnitPrice() As Decimal
        Return (Me.LinePrice + Me.LineDiscountPromo + Me.LineDiscount) / Me.Qty
    End Function

    Function TotalDiscount() As Decimal
        Return Me.LineDiscount + Me.LineDiscountPromo
    End Function

    ''' <summary>
    ''' Unit Price * Qty after discounts
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property LinePrice As Decimal

    ''' <summary>
    ''' Any personalisation for this item, for example the name to be printed on the back of a garment.
    ''' </summary>
    ''' <returns></returns>
    Property FreeText As String

    <Range(0, Decimal.MaxValue)>
    Property LineDiscount As Decimal

    <Range(0, Decimal.MaxValue)>
    Property LineDiscountPromo As Decimal
    ''' <summary>
    '''ReadOnly. Not required for inserting
    ''' </summary>
    ''' <returns></returns>
    Property Description As String
    Property GiftCardDetails As clsGiftCardItemDetails

    ''' <summary>
    ''' Certain products are not permitted to be discounted. This flag records if that is the case or not.
    ''' </summary>
    ''' <returns></returns>
    Property NoDiscountAllowed As Boolean
End Class

Public Class clsTillSaleItem
    Inherits clsSaleItemBase

    Property ProductOptions As IEnumerable(Of clsSaleItemBase)

End Class

Public Class clsSalesItemRefundDetails
    Property OriginalSalesRef As String
    Property OriginalSalesLine As Integer
End Class

Public Class clsSalesItem
    Inherits clsSaleItemBase

    Implements IValidatableObject

    ''' <summary>
    ''' If the item is being ordered (not taken away at POS), then this is the amount they are paying for it now. 
    ''' </summary>
    ''' <returns></returns>
    <Range(0, Integer.MaxValue)>
    Property DepositAmount As Decimal?

    ''' <summary>
    ''' The Sales Channel. See api/Sales/Channels
    ''' </summary>
    ''' <returns></returns>
    Property CustomerAction As Integer = -1

    ''' <summary>
    ''' A record of any functions that were authorised by a manager and when
    ''' </summary>
    ''' <returns></returns>
    Property AdminOverrides As IEnumerable(Of clsAdminOverride)

    Function PaidAmount() As Decimal

        If Me.DepositAmount IsNot Nothing Then
            Return Me.DepositAmount
        Else
            Return Me.LinePrice
        End If
        'Select Case Me.CustomerAction
        '    Case CustomerActionEnum.CustomerOrderItem
        '        Return Me.DepositAmount
        '    Case Else
        '        Return Me.LinePrice
        'End Select
    End Function

    ''' <summary>
    ''' A unique number for each line in the sale. Start at 1 and increment.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <Key>
    Property LineID As Integer

    <EnumDataType(GetType(ItemKitTypeEnum))>
    Property KitProductType As ItemKitTypeEnum = ItemKitTypeEnum.NormalItem

    Function KitSequence() As Long?
        If Me.KitParentLine IsNot Nothing Then
            Return Me.KitParentLine
        ElseIf Me.IsKitHeader Then
            Return Me.LineID
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' If this item is a kit component, then this property determines which item in the sale is the kit header
    ''' </summary>
    ''' <returns></returns>
    Property KitParentLine As Long?

    Function IsKitHeader() As Boolean
        Select Case Me.KitProductType
            Case ItemKitTypeEnum.FixedHeader, ItemKitTypeEnum.VariableHeader
                Return True
        End Select
        Return False
    End Function

    Property RefundDetails As clsSalesItemRefundDetails

    Function IsKitComponent() As Boolean
        Select Case Me.KitProductType
            Case ItemKitTypeEnum.FixedComponent, ItemKitTypeEnum.VariableComponent
                Return True
        End Select
        Return False
    End Function

    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim results As New List(Of ValidationResult)

        'If Me.DepositAmount IsNot Nothing And Me.CustomerAction = CustomerActionEnum.NoCustomerAction Then
        '    results.Add(New ValidationResult("Cannot specify deposit amount when there is no Customer Action"))
        'End If

        If Me.KitParentLine Is Nothing AndAlso Me.IsKitComponent Then
            results.Add(New ValidationResult("Must specify the Kit Parent Line property when an item is marked as a kit component"))
        End If

        If Me.KitParentLine IsNot Nothing AndAlso Not Me.IsKitComponent Then
            results.Add(New ValidationResult("The Kit Parent Line property should be null when an item is not marked as a kit component"))
        End If

        If Me.RefundDetails IsNot Nothing AndAlso Me.Qty >= 0 Then
            results.Add(New ValidationResult($"RefundDetails present on line {Me.LineID} where the quantity is positive"))
        End If

        If Me.Qty < 0 And Me.LinePrice > 0 Then
            results.Add(New ValidationResult($"Item line {Me.LineID} has a negative qty, but the line price is positive"))
        End If

        If Me.Qty > 0 And Me.LinePrice < 0 Then
            results.Add(New ValidationResult($"Item line {Me.LineID} has a positive qty, but the line price is negative"))
        End If

        If Me.Qty = 0 Then
            results.Add(New ValidationResult($"Item line {Me.LineID} has a qty of zero, this is not allowed"))
        End If

        Return results
    End Function

    ''' <summary>
    ''' Optional. If omitted, the VAT ID assigned to the product will be used. If the goods are being exported outside of the UK for instance, the VAT ID might be different to what is assigned on the product. See api/TaxCodes/All for a list of the possible values
    ''' </summary>
    ''' <returns></returns>
    Property VatID As Integer?

    'may come online later
    'Property ProductOptions As IEnumerable(Of clsSaleItemBase)

End Class

Public Class clsTillSaleItems
    Inherits EskimoBaseClass

    ''' <summary>
    ''' A collection of the items being ordered
    ''' </summary>
    ''' <returns></returns>
    Property Items As IEnumerable(Of clsTillSaleItem)

    ''' <summary>
    ''' Running in Waitress mode?
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property Hospitality As Boolean

    ''' <summary>
    ''' The date of the sale/table creation.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property ActionDate As Date

    ''' <summary>
    ''' Optional. If passed, then the order is to be paid for, otherwise a Table Tab is created or appended to when running in waitress mode, or a layaway is created when running in retail mode.
    ''' </summary>
    ''' <returns></returns>
    Property Tenders As IEnumerable(Of clsTenderEntry)

    ''' <summary>
    ''' The Table Number 
    ''' </summary>
    ''' <returns></returns>
    Property ScopeID As Integer?

    ''' <summary>
    ''' The ID of the Area the table is in. Shoud match an ID from api/TillMenu/Areas
    ''' </summary>
    ''' <returns></returns>
    Property AreaID As Integer?

End Class

Public Class clsGiftCardItemDetails
    Inherits clsGiftCardBase

    ''' <summary>
    ''' If the card was a new card (i.e. not activated before this sale) then pass True, but if the card was already activated and was just having extra money added to it, then pass False
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property Activated As Boolean

End Class