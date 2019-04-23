Imports System.ComponentModel.DataAnnotations

Public Class GetSaleArguments
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
    ''' If only the Header information is required, then pass false, otherwise pass true and more information about the ordered items will be included in the Items field.
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

    ''' <summary>
    ''' Optional. Receipt Number
    ''' </summary>
    ''' <returns></returns>
    Public Property ReceiptNumber As Integer?

    ''' <summary>
    ''' Optional. Till Number
    ''' </summary>
    ''' <returns></returns>
    Public Property TillNumber As Integer?

    ''' <summary>
    ''' Optional. The unique external sales identifier.
    ''' </summary>
    ''' <returns></returns>
    Public Property ExternalIdentifier As String

End Class
