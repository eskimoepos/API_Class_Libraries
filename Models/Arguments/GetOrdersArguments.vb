﻿Imports System.ComponentModel.DataAnnotations

Public Class GetOrdersArguments
    Implements iControllerArguments

    ''' <summary>
    ''' Return orders greater than this date/time
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property FromDate As Date

    ''' <summary>
    ''' Return orders greater earlier this date/time
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property ToDate As Date

    ''' <summary>
    ''' The type of orders to return. 
    ''' </summary>
    ''' <returns></returns>
    <EnumDataType(GetType(clsOrder.OrderTypeEnum))>
    <Required>
    Property OrderType As clsOrder.OrderTypeEnum

    ''' <summary>
    ''' If only the Eskimo Customer ID required, then pass false, otherwise pass true and more information about the customer will be included in the CustomerInfo field.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property IncludeCustomerDetails As Boolean

    ''' <summary>
    ''' If only the Header information is required, then pass false, otherwise pass true and more information about the ordered items will be included in the OrderedItems field.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property IncludeProductDetails As Boolean

    ''' <summary>
    ''' The unique ID of the customer. This is in the format 000-000000 where the first three digits represent the Shop/Showroom code. 
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

End Class
