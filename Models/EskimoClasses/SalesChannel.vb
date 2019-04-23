Imports System.ComponentModel.DataAnnotations

Public Class clsSalesChannel
    Enum ChannelTypeEnum

        ''' <summary>
        ''' A custom Channel Type
        ''' </summary>
        Custom = -2

        ''' <summary>
        ''' The customer has taken this item. Nothing further to action.
        ''' </summary>
        CarryOutSale = -1

        ''' <summary>
        ''' There is not enough stock to fulfil this item. The customer has placed an order for it. They will come back in to collect when available.
        ''' </summary>
        CustomerOrderItem = 0

        ''' <summary>
        ''' 
        ''' </summary>
        CustomerSale = 1

        ''' <summary>
        ''' Item has been ordered via a website and needs to be either collected or dispatched.
        ''' </summary>
        WebOrder = 2

        ''' <summary>
        ''' This is for items that will be fulfilled from a different location (perhaps a warehouse)
        ''' </summary>
        MailOrder = 3

        ''' <summary>
        ''' Order has been generated and entered via eBay.
        ''' </summary>
        eBay = 4

        ''' <summary>
        ''' Order has been generated and entered via Amazon. This is an FBM order. FBA orders come in as No Customer Action as there is no dispatching to perform on these.
        ''' </summary>
        Amazon = 5

    End Enum

    <Required>
    Property ChannelID As Integer

    Property AcceptsDeposits As Boolean

    Property Description As String

    <EnumDataType(GetType(ChannelTypeEnum))>
    <Required>
    Property ChannelType As ChannelTypeEnum

End Class
