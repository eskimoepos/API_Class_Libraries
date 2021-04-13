Imports System.ComponentModel.DataAnnotations

Public Class GetModifiedOrdersArguments
    Implements iControllerArguments

    ''' <summary>
    ''' Return orders modified on or later than this date/time
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property FromDate As Date

    ''' <summary>
    ''' Return orders modified before this date/time
    ''' </summary>
    ''' <returns></returns>
    Property ToDate As Date

    ''' <summary>
    ''' The type of orders to return. The ChannelID, see api/Sales/Channels
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property OrderType As Integer

    ''' <summary>
    ''' If only the Eskimo Customer ID is required, then pass false, otherwise pass true and more information about the customer will be included in the CustomerInfo field.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property IncludeCustomerDetails As Boolean

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
    ''' Optional. The Code of the shop the order is assigned to. See api/Shops/All
    ''' </summary>
    ''' <returns></returns>
    <StringLength(3)>
    Public Property StoreNumber As String

End Class
