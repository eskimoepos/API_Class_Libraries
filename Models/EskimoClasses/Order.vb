﻿Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.ComponentModel
Imports EskimoClassLibraries
Imports System.Globalization

Public Class AddressConverter
    Inherits ExpandableObjectConverter
    Public Overrides Function CanConvertTo(context As ITypeDescriptorContext, destinationType As Type) As Boolean
        If (destinationType Is GetType(clsOrderAddressInfo)) Then
            Return True
        End If
        Return MyBase.CanConvertFrom(context, destinationType)
    End Function
    Public Overloads Overrides Function ConvertTo( _
                              ByVal context As ITypeDescriptorContext, _
                              ByVal culture As CultureInfo, _
                              ByVal value As Object, _
                              ByVal destinationType As System.Type) _
                     As Object
        If (destinationType Is GetType(System.String) _
            AndAlso TypeOf value Is clsOrderAddressInfo) Then

            Dim add As clsOrderAddressInfo = CType(value, clsOrderAddressInfo)

            Return add.AddressLine1 & "," & add.PostalTown
        End If
        Return MyBase.ConvertTo(context, culture, value, destinationType)
    End Function
End Class

''' <summary>
''' The Order Class. This contains the header information about the order. The products ordered are in a collection within the OrderedItems property.
''' </summary>
Public Class clsOrder
    Inherits EskimoBaseClass

    Enum OrderTypeEnum
        'CustomerOrder = 0
        'CustomerSale = 1
        WebOrder = 2
        'MailOrder = 3
        'eBayOrder = 4
        'AmazonOrder = 5
    End Enum

    ''' <summary>
    ''' The numerical ID of the order. This is not an Eskimo ID, but rather the ID generated by website/cart. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Range(0, Int32.MaxValue, ErrorMessage:="A positive order ID must be submitted")>
    Property order_id As Integer

    ''' <summary>
    ''' This is an optional secondary reference. Some references are text-based and therefore cannot be inserted into the order_id field.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(200, ErrorMessage:="The External Identifier length must be 200 characters or less.", MinimumLength:=0)>
    Property ExternalIdentifier As String

    ''' <summary>
    ''' The sales channel of the order being inserted. See api/Sales/Channels
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property OrderType As Integer = OrderTypeEnum.WebOrder

    ''' <summary>
    ''' The Eskimo Customer ID in the format 123-123456.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Must be a valid (existing) customer ID.</remarks>
    <Required>
    <StringLength(10, ErrorMessage:=clsCustomer.CustomerLengthMsg, MinimumLength:=10)>
    <RegularExpression(clsCustomer.CustomerIDFormat)>
    <ValidCustomer>
    Property eskimo_customer_id As String

    ''' <summary>
    ''' The date the customer placed the order
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property order_date As DateTime

    ''' <summary>
    ''' The total value of the order.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property invoice_amount As Decimal

    ''' <summary>
    ''' The amount of the order that has been paid.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property amount_paid As Decimal

    ''' <summary>
    ''' Exclude if equal to the invoice address
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <TypeConverter(GetType(AddressConverter))>
    Property DeliveryAddress As clsOrderAddressInfo

    <TypeConverter(GetType(AddressConverter))>
    <Required>
    Property InvoiceAddress As clsOrderAddressInfo

    ''' <summary>
    ''' All the items the customer purchased
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property OrderedItems As New List(Of clsOrderItem)

    ''' <summary>
    ''' Optional reference that the customer wants to refer to the order as. I.e. 'Presents for Debbie'
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(30)>
    Property CustomerReference As String

    ''' <summary>
    ''' Free text delivery notes. i.e. 'Please leave package in porch if no reply.'
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property DeliveryNotes As String

    ''' <summary>
    ''' The ID of the shipping rate used on the order. See api/Orders/FulfilmentMethods
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property ShippingRateID As Int16

    ''' <summary>
    ''' The Shipping Value (inc. tax) 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property ShippingAmountGross As Decimal

    Function CalculatedOrderTotal() As Decimal
        Dim t As Decimal = 0

        t = Me.ShippingAmountGross
        For Each i In Me.OrderedItems
            t += i.line_value
        Next
        Return t

    End Function

    Public Sub New()
        'Me.DeliveryAddress = New clsOrderAddressInfo
        'Me.InvoiceAddress = New clsOrderAddressInfo
    End Sub
End Class

Public Class clsOrderReturn

    ''' <summary>
    ''' An amount of money to return to the customer unrelated to carriage or products. This may be to appease an unhappy customer.
    ''' </summary>
    ''' <returns></returns>
    <Range(0, Double.PositiveInfinity)>
    Property GoodwillGestureAmount As Decimal
    <Range(0, Double.PositiveInfinity)>
    Property CarriageAmountGross As Decimal
    <Required>
    Property RefundProducts As IEnumerable(Of clsOrderReturnLine)
    Property OrderExternalIdentifier As String
    Property ReturnExternalIdentifier As String
    Property ReturnDate As Date
    Property Order_ID As Integer
    <Required>
    Property OrderType As Integer

End Class

Public Class clsIdentifier
    Property ID As Integer
    Property ExternalIdentifier As String
End Class

Public Class clsOrderReturnLine

    Property SKU As String

    <Range(1, Int16.MaxValue, ErrorMessage:="A positive quantity must be submitted")>
    Property Qty As Integer


End Class

Public Class clsOrderAddressInfo
    Inherits System.ComponentModel.ExpandableObjectConverter

    ''' <summary>
    ''' For the attention of this person. Free text string value, i.e. Bill Smith
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(255)>
    Property FAO As String

    ''' <summary>
    ''' First line of the address
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    <StringLength(255)>
    Property AddressLine1 As String

    ''' <summary>
    ''' Optional. Second Line of the address
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(255)>
    Property AddressLine2 As String

    ''' <summary>
    ''' Optional. Third Line of the address
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(255)>
    Property AddressLine3 As String

    ''' <summary>
    ''' The postal town
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    <StringLength(255)>
    Property PostalTown As String

    ''' <summary>
    ''' The Postal County (or State)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(255)>
    Property County As String

    ''' <summary>
    ''' The 2 digit country code, for United Kingdom, use GB http://www.worldatlas.com/aatlas/ctycodes.htm
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    <StringLength(2, ErrorMessage:="The code must be 2 digits.", MinimumLength:=2)> _
    Property CountryCode As String

    ''' <summary>
    ''' The postal code
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(16)>
    Property PostCode As String

End Class