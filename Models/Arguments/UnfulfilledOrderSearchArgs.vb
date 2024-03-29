﻿Imports System.ComponentModel.DataAnnotations
Public Class UnfulfilledOrderSearchArgs
    Implements iControllerArguments

    ''' <summary>
    ''' A list of channel IDs that you want to see results for. Pass null to not filter
    ''' </summary>
    ''' <returns></returns>
    Property ChannelIDs As IEnumerable(Of Integer)

    ''' <summary>
    ''' A list of shipping type IDs that you want to see results for. Pass null to not filter
    ''' </summary>
    ''' <returns></returns>
    Property ShippingTypeIDs As IEnumerable(Of Integer)



    '''' <summary>
    '''' Search for orders that matching this external reference given when inserting the order.
    '''' </summary>
    '''' <returns></returns>
    'Property ExternalIdentifier As String

    '''' <summary>
    '''' Return orders greater than this date/time
    '''' </summary>
    '''' <returns></returns>
    '<Required>
    'Property FromDate As Date

    '''' <summary>
    '''' Return orders earlier than this date/time
    '''' </summary>
    '''' <returns></returns>
    '<Required>
    'Property ToDate As Date

    '''' <summary>
    '''' The type of orders to return. The ChannelID, see api/Sales/Channels
    '''' </summary>
    '''' <returns></returns>
    '<Required>
    'Property OrderType As Integer

    '''' <summary>
    '''' If only the Eskimo Customer ID is required, then pass false, otherwise pass true and more information about the customer will be included in the CustomerInfo field.
    '''' </summary>
    '''' <returns></returns>
    '<Required>
    'Property IncludeCustomerDetails As Boolean

    '''' <summary>
    '''' If only the Header information is required, then pass false, otherwise pass true and more information about the ordered items will be included in the OrderedItems field.
    '''' </summary>
    '''' <returns></returns>
    '<Required>
    'Property IncludeProductDetails As Boolean

    ''' <summary>
    ''' Optional. The unique ID of the customer. This is in the format 000-000000 where the first three digits represent the Shop/Showroom code. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(10, ErrorMessage:=clsCustomer.CustomerLengthMsg, MinimumLength:=10)>
    <RegularExpression(clsCustomer.CustomerIDFormat)>
    <ValidCustomer>
    Public Property CustomerID As String


    ''' <summary>
    ''' The Code of the shop the order is assigned to. See api/Shops/All
    ''' </summary>
    ''' <returns></returns>
    <StringLength(3)>
    Public Property StoreNumber As String

    ''' <summary>
    ''' The Web Order ID or the Customer Order ID. Optional.
    ''' </summary>
    ''' <returns></returns>
    Public Property OrderNumber As Integer?

    ''' <summary>
    ''' Specifies whethere the order items should be included in the returned results or not. True if omitted
    ''' </summary>
    ''' <returns></returns>
    Public Property IncludeOrderItems As Boolean = True

    ''' <summary>
    ''' With this option on, orders will still be included in the results if there is items that don't have sufficient stock, but those items will not be included.
    ''' </summary>
    ''' <returns></returns>
    Public Property HideOutOfStockOrderedItems As Boolean

    ''' <summary>
    ''' If any ordered products on an order are out of stock, don't return that order in the results as it cannot be completely processed by a dispatch team.
    ''' </summary>
    ''' <returns></returns>
    Public Property HideOrdersWithOutOfStockItems As Boolean

End Class


