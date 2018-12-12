Imports System.ComponentModel.DataAnnotations

Public Class clsTillMenuUnitInfo
    Inherits EskimoBaseClass

    Enum OptionTimingEnum
        ''' <summary>
        ''' This option is turned off 
        ''' </summary>
        Off = 0

        ''' <summary>
        ''' This should occur at the start of each sale
        ''' </summary>
        StartOfSale = 1

        ''' <summary>
        ''' This should occur before going to the tenders screen, unless it has been applied manually.
        ''' </summary>
        WhenPaying = 2
    End Enum

    <Required>
    <StringLength(3, ErrorMessage:="The {0} must be 3 characters long.", MinimumLength:=3)>
    Property StoreNumber As String

    <Required>
    Property StoreName As String

    ''' <summary>
    ''' The till number. There can be duplicates of this per organisation, but not per store.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property TillNumber As Integer

    ''' <summary>
    ''' Unique per organisation. The primary Key of the Till.
    ''' </summary>
    ''' <returns></returns>
    <Key>
    <Required>
    Property TillID As Integer

    <Required>
    Property TillName As String

    Property SKUCount As Long

    Property AutoSalesCode As OptionTimingEnum = OptionTimingEnum.Off
    Property PromptForSendOfflineSales As Boolean
    ''' <summary>
    ''' How often to check and see if any offline sales need uploading. The value is the number of seconds. (Zero = Off)
    ''' </summary>
    ''' <returns></returns>
    Property UploadOfflineSalesInterval As Integer
    ''' <summary>
    ''' How often to pull the live stock levels from the server. The value is the number of seconds. (Zero = Off)
    ''' </summary>
    ''' <returns></returns>
    Property UpdateStockInterval As Integer
    Property ReceiptOptions As New clsReceiptOptions
    Property HardwareOptions As New clsHardwareOptions
    Property OperatorOptions As New clsOperatorOptions
    Property CustomerOptions As New clsCustomerOptions
    Property ProductOptions As New clsProductOptions
    Property SaleOptions As New clsSaleOptions
    Property TenderOptions As New clsTenderOptions
    Property FunctionButtons As New clsFunctions
    Property Promotions As New List(Of clsPromotion)
End Class
