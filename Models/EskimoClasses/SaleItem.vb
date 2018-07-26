Imports System.ComponentModel.DataAnnotations

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
    ''' The UnitPrice of the product after discounts
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <Range(0, Integer.MaxValue)>
    Property UnitPrice As Decimal = 0

    ''' <summary>
    ''' Read-only property. Simply multiplies the Unit Price by the Quantity.
    ''' </summary>
    ''' <returns></returns>
    ReadOnly Property LinePrice As Decimal
        Get
            Return Me.UnitPrice * Me.Qty
        End Get
    End Property

    ''' <summary>
    ''' Any personalisation for this item, i.e. 'Treat as Main Meal.'
    ''' </summary>
    ''' <returns></returns>
    Property FreeText As String
    <Range(0, Decimal.MaxValue)>
    Property LineDiscount As Decimal
    <Range(0, Decimal.MaxValue)>
    Property LineDiscountPromo As Decimal

End Class

Public Class clsTillSaleItem
    Inherits clsSaleItemBase

    Property ProductOptions As IEnumerable(Of clsSaleItemBase)

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

    '<EnumDataType(GetType(CustomerActionEnum))>
    Property CustomerAction As CustomerActionEnum = CustomerActionEnum.NoCustomerAction

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
    ''' A unique number for each line in the sale. Start at 1 and 
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <Key>
    Property LineID As Integer

    <EnumDataType(GetType(ItemKitTypeEnum))>
    Property KitProductType As ItemKitTypeEnum = ItemKitTypeEnum.NormalItem

    ''' <summary>
    ''' If this item is a kit component, then this property determines which item in the sale is the kit header
    ''' </summary>
    ''' <returns></returns>
    Property KitParentLine As Integer?

    Function IsKitHeader() As Boolean
        Select Case Me.KitProductType
            Case ItemKitTypeEnum.FixedHeader, ItemKitTypeEnum.VariableHeader
                Return True
        End Select
        Return False
    End Function

    Function IsKitComponent() As Boolean
        Select Case Me.KitProductType
            Case ItemKitTypeEnum.FixedComponent, ItemKitTypeEnum.VariableComponent
                Return True
        End Select
        Return False
    End Function

    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim results As New List(Of ValidationResult)

        If Me.DepositAmount <> 0 And Me.CustomerAction = CustomerActionEnum.NoCustomerAction Then
            results.Add(New ValidationResult("Cannot specify deposit amount when there is no Customer Action"))
        End If

        If Me.KitParentLine Is Nothing AndAlso Me.IsKitComponent Then
            results.Add(New ValidationResult("Must specify the Kit Parent Line property when an item is marked as a kit component"))
        End If

        If Me.KitParentLine IsNot Nothing AndAlso Not Me.IsKitComponent Then
            results.Add(New ValidationResult("The Kit Parent Line property should be null when an item is not marked as a kit component"))
        End If

        Return results
    End Function

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