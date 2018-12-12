Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class clsSale
    Inherits EskimoBaseClass

    Implements IValidatableObject

    ''' <summary>
    ''' Optional. The version of the EPOS software used for the sale. Useful for fault tracking.
    ''' </summary>
    ''' <returns></returns>
    Property TillSystemVersion As Long?

    ''' <summary>
    ''' The customer gave permission for their receipt to be sent via email. 
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property CustomerRequestedEReceipt As Boolean

    ''' <summary>
    ''' The products in the sale
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property Items As List(Of clsSalesItem)

    ''' <summary>
    ''' The tenders used to pay for the sale.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property Tenders As IEnumerable(Of clsTenderEntry)

    ''' <summary>
    ''' From api/TillMenu/UnitInfo
    ''' </summary>
    <Required>
    Public TillID As Integer

    ''' <summary>
    ''' Optional. If passed, this will be used, otherwise the next receipt number will be issued by the system.
    ''' </summary>
    Public ReceiptNumber As Integer?

    ''' <summary>
    ''' Readonly. Not required for inserting. Shop Code that the sale is assigned to. See api/Shops/All
    ''' </summary>
    <StringLength(3, ErrorMessage:="The Eskimo StoreID length must be 3 characters.", MinimumLength:=3)>
    Public StoreID As String

    ''' <summary>
    ''' This is an optional secondary reference. 
    ''' </summary>
    ''' <returns></returns>
    <StringLength(200, ErrorMessage:="The External Identifier length must be 200 characters or less.", MinimumLength:=0)>
    Property ExternalIdentifier As String

    ''' <summary>
    ''' The Eskimo Customer ID in the format 123-123456. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Must be a valid (existing) customer ID.</remarks>
    <StringLength(10, ErrorMessage:=clsCustomer.CustomerLengthMsg, MinimumLength:=10)>
    <RegularExpression(clsCustomer.CustomerIDFormat)>
    <ValidCustomer>
    Property EskimoCustomerID As String

    ''' <summary>
    ''' The date the customer placed the sale
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property DatePlaced As DateTime

    ''' <summary>
    ''' Optional. Only applicable if items in the sale are marked to be ordered. This is the date the customer would like their order delivered. This could be specified because they are going on holiday and do not want delivery to occur until they return.
    ''' </summary>
    ''' <returns></returns>
    Property DeliveryDate As Date?

    ''' <summary>
    ''' The Invoice Address for any products ordered. Can be left null if irrevant or there are no changes to the address. If populated though, the address will either be added or updated where necessary
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property InvoiceAddress As clsAddress

    ''' <summary>
    ''' The Delivery Address for any products ordered. Can be left null if irrevant or there are no changes to the address. If populated though, the address will either be added or updated where necessary
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property DeliveryAddress As clsAddress

    ''' <summary>
    ''' Optional. If any of the items are for a sales channel that creates an order for a customer, this is the shop that the goods can be collected from. See api/Shops/All
    ''' </summary>
    ''' <returns></returns>
    <StringLength(3, ErrorMessage:="The ClickAndCollectShop length must be 3 characters.", MinimumLength:=3)>
    Property ClickAndCollectShop As String

    ''' <summary>
    ''' When products are being ordered, this is the Address Reference for the Invoice Address. Defaults to 'MAIN' if not passed.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(12, ErrorMessage:="The Invoice Address Ref length must be between 1 and 12 characters.", MinimumLength:=1)>
    Property InvoiceAddressRef As String = "MAIN"

    ''' <summary>
    ''' When products are being ordered, this is the Address Reference for the Delivery Address. 
    ''' </summary>
    ''' <returns></returns>
    <StringLength(12, ErrorMessage:="The Delivery Address Ref length must be between 1 and 12 characters.", MinimumLength:=1)>
    Property DeliveryAddressRef As String

    ''' <summary>
    ''' The person's name that will receive the invoice when items have been ordered.
    ''' </summary>
    ''' <returns></returns>
    Property InvoiceFAO As String

    ''' <summary>
    ''' When items have been ordered, this is the name of the person that the parcel is destined for. Not necessarily the same as the customer making the purchase.
    ''' </summary>
    ''' <returns></returns>
    Property DeliveryFAO As String

    ''' <summary>
    ''' Optional reference that the customer wants to refer to the order as. I.e. 'Presents for Debbie'
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(30)>
    Property CustomerReference As String

    ''' <summary>
    ''' Free text order notes. i.e. 'Please ship all items in the same consignment.'
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property OrderNotes As String

    ''' <summary>
    ''' Free text delivery notes. i.e. 'Please leave package in porch if no reply.'
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property DeliveryNotes As String

    ''' <summary>
    ''' The ID of the shipping rate used on the sale. See api/Orders/FulfilmentMethods. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ShippingRateID As Integer?

    ''' <summary>
    ''' The Shipping Value (inc. tax) 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ShippingAmountGross As Decimal = 0

    ''' <summary>
    ''' Optional. If the sales channel of any of them items will generate an order, this field specifies the status of that order. See api/Orders/StatusCodes
    ''' </summary>
    ''' <returns></returns>
    Property OrderStatus As Integer = 30

    Function CalculatedOrderTotal() As Decimal
        Dim t As Decimal = 0

        t = Me.ShippingAmountGross
        t += Me.Items.Sum(Function(x) x.LinePrice)

        Return t

    End Function

    Public Sub New()
        'Me.DeliveryAddress = New clsOrderAddressInfo
        'Me.InvoiceAddress = New clsOrderAddressInfo
    End Sub

    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim results As New List(Of ValidationResult)
        Dim tendered_sum As Decimal
        Dim item_paid_sum As Decimal
        Dim strDirection As String
        Dim decDiff As Decimal
        Dim IDCount As Integer

        If Me.Tenders Is Nothing Then
            results.Add(New ValidationResult($"No Tender entries were passed."))
        End If

        tendered_sum = Me.Tenders.Sum(Function(x) x.Amount)
        item_paid_sum = Me.Items.Sum(Function(x) x.PaidAmount) + Me.ShippingAmountGross

        If tendered_sum - item_paid_sum <> 0 Then

            If tendered_sum < item_paid_sum Then
                strDirection = "down"
                decDiff = item_paid_sum - tendered_sum
            Else
                strDirection = "up"
                decDiff = tendered_sum - item_paid_sum
            End If

            results.Add(New ValidationResult($"Tenders sum is {strDirection} by {decDiff.ToString("c")}. Total tendered is {tendered_sum.ToString("c")} but the order total is {item_paid_sum.ToString("c")}"))
        End If

        If Me.EskimoCustomerID Is Nothing Then
            'no customer passed

            For Each itm In Me.Items.Where(Function(x) x.CustomerAction <> clsSaleItemBase.CustomerActionEnum.NoCustomerAction)
                results.Add(New ValidationResult($"Item line {itm.LineID} is set to have a customer action of {itm.CustomerAction} but no customer ID was passed."))
                Exit For
            Next
        Else 'customer id IS passed

            If (Me.InvoiceAddressRef Is Nothing OrElse Me.InvoiceAddressRef = "") OrElse (Me.DeliveryAddressRef Is Nothing OrElse Me.DeliveryAddressRef = "") Then
                For Each itm In Me.Items.Where(Function(x)
                                                   Select Case x.CustomerAction
                                                       Case clsSaleItemBase.CustomerActionEnum.MailOrderItem
                                                           Return True
                                                       Case Else
                                                           Return False
                                                   End Select
                                               End Function)

                    results.Add(New ValidationResult($"Item line {itm.LineID} is set to have a customer action of {itm.CustomerAction} so a delivery and an invoice address ref must also be passed."))

                Next
            End If

        End If

        If Me.ClickAndCollectShop IsNot Nothing AndAlso Me.ClickAndCollectShop <> "" AndAlso Me.DeliveryAddress IsNot Nothing Then
            results.Add(New ValidationResult($"The DeliveryAddress cannot be passed as well as the ClickAndCollectShop; pass one or the other."))
        End If

        If Me.ShippingAmountGross <> 0 AndAlso Me.ShippingRateID Is Nothing Then
            For Each itm In Me.Items.Where(Function(x)
                                               Select Case x.CustomerAction
                                                   Case clsSaleItemBase.CustomerActionEnum.AmazonItem, clsSaleItemBase.CustomerActionEnum.eBayItem, clsSaleItemBase.CustomerActionEnum.MailOrderItem, clsSaleItemBase.CustomerActionEnum.WebSalesItem
                                                       Return True
                                               End Select
                                               Return False
                                           End Function)
                results.Add(New ValidationResult($"Item line {itm.LineID} is set to have a customer action of {itm.CustomerAction} so a Shipping Rate ID must also be passed."))
            Next
        End If



        For Each itm In Me.Items.Where(Function(x) x.KitParentLine IsNot Nothing AndAlso Not Me.Items.Exists(Function(y) y.LineID = x.KitParentLine And y.CustomerAction = x.CustomerAction))
            results.Add(New ValidationResult($"If a Kit Parent Line is specified, it must match a valid LineID in the Items collection. Parent {itm.KitParentLine} is referenced from Line {itm.LineID}, but this does not exist."))
        Next

        For Each itm In Me.Items.Where(Function(x) x.KitParentLine IsNot Nothing AndAlso x.KitParentLine = x.LineID)
            results.Add(New ValidationResult($"If a Kit Parent Line is specified, it must match a valid LineID other than itself. Line {itm.LineID}, refers to itself."))
        Next

        For Each itm In Me.Items.Where(Function(x) x.LinePrice <> 0 AndAlso (x.KitProductType = clsSaleItemBase.ItemKitTypeEnum.FixedHeader OrElse x.KitProductType = clsSaleItemBase.ItemKitTypeEnum.VariableHeader))
            results.Add(New ValidationResult($"Kit Parent Lines cannot have a monetary value. Line {itm.LineID}, has a value of {itm.LinePrice.ToString("c")}."))
        Next

        For Each itm In Me.Items.Where(Function(x) x.DepositAmount IsNot Nothing AndAlso x.Qty < 0)
            results.Add(New ValidationResult($"Line {itm.LineID} specifies a deposit amount, but it is a refund item."))
        Next

        For Each itm In Me.Items.Where(Function(x) x.DepositAmount IsNot Nothing AndAlso x.DepositAmount > x.LinePrice)
            results.Add(New ValidationResult($"Line {itm.LineID} specifies a deposit amount of {itm.DepositAmount.ToString("c")}, which is higher than the line price of {itm.LinePrice.ToString("c")}."))
        Next

        For Each itm In Me.Items.Where(Function(x) x.KitParentLine IsNot Nothing AndAlso Me.Items.Exists(Function(y) y.LineID = x.KitParentLine AndAlso y.CustomerAction = x.CustomerAction))
            Dim parent As clsSalesItem

            parent = Me.Items.Where(Function(z) z.LineID = itm.KitParentLine AndAlso z.CustomerAction = itm.CustomerAction).FirstOrDefault

            If parent IsNot Nothing Then

                If itm.KitProductType = clsSaleItemBase.ItemKitTypeEnum.FixedComponent AndAlso parent.KitProductType <> clsSaleItemBase.ItemKitTypeEnum.FixedHeader Then
                    results.Add(New ValidationResult($"Item line {itm.LineID} is marked as {itm.KitProductType} and refers to Kit Parent line {itm.KitParentLine}. However, the Kit Type of {parent.KitProductType} was found, rather than the expected {clsSaleItemBase.ItemKitTypeEnum.FixedHeader}"))
                End If

                If itm.KitProductType = clsSaleItemBase.ItemKitTypeEnum.VariableComponent AndAlso parent.KitProductType <> clsSaleItemBase.ItemKitTypeEnum.VariableHeader Then
                    results.Add(New ValidationResult($"Item line {itm.LineID} is marked as {itm.KitProductType} and refers to Kit Parent line {itm.KitParentLine}. However, the Kit Type of {parent.KitProductType} was found, rather than the expected {clsSaleItemBase.ItemKitTypeEnum.VariableHeader}"))
                End If
            End If

        Next

        For Each itm In Me.Items
            IDCount = Me.Items.Where(Function(x) x.LineID = itm.LineID).Count
            If IDCount > 1 Then
                results.Add(New ValidationResult($"The LineID property need to be unique. ID {itm.LineID} is specified {IDCount} times."))
                Exit For
            End If
        Next
        'Dim q = From x As clsTillSalesItem In Me.Items Group By x.LineID 

        Return results

    End Function

    ''' <summary>
    ''' Optional. If passed, it should match a CodeID from api/TillMenu/SourceCodes
    ''' </summary>
    ''' <returns></returns>
    Property SourceCodeID As Integer?

    ''' <summary>
    ''' Optional. If the operator has entered a new Source Code that is not present in the api/TillMenu/SourceCodes call, then this can be used to potentially create a new Source Code, if the setup has this behaviour enabled.
    ''' </summary>
    ''' <returns></returns>
    Property CustomSourceCodeText As String

    ''' <summary>
    ''' Optional. The Eskimo Operator ID of the person who performed the sale. If omitted, the operator 'SYSTEM' will be used.
    ''' </summary>
    ''' <returns></returns>
    Property OperatorID As String

End Class
