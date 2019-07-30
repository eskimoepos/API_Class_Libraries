''' <summary>
''' Represents a method of paying for something.
''' </summary>
Public Class clsTender

    Inherits EskimoBaseClass

    ''' <summary>
    ''' The Eskimo identifier for the Tender item
    ''' </summary>
    ''' <returns></returns>
    Property ID As Integer

    ''' <summary>
    ''' The description of the Tender item, i.e. Cash
    ''' </summary>
    ''' <returns></returns>
    Property Description As String

    ''' <summary>
    ''' Specifies if over-tendering is allowed. It TRUE, a CHANGE entry can be created for the difference. If FALSE, then the POS will deny using a tender method if the value is greater than the remaining balance.
    ''' </summary>
    ''' <returns></returns>
    Property AllowChange As Boolean

    ''' <summary>
    ''' Only applicable for when AllowChange is true. If true (usually Cash), the same tender pressed will be automatically returned as the change. If false, then the operator can choose the tender to issue the change against.
    ''' </summary>
    ''' <returns></returns>
    Property AutoCompleteChange As Boolean

    ''' <summary>
    ''' Controls if the cash drawer is to be fired at the completion of the sale when this tender method is used.
    ''' </summary>
    ''' <returns></returns>
    Property OpenCashDrawer As Boolean

    ''' <summary>
    ''' Not all tender methods can be used to perform refunds (e.g. Cheque). This property determines if the tender should even appear in the list when the sales value is less than zero.
    ''' </summary>
    ''' <returns></returns>
    Property AllowRefunds As Boolean

    ''' <summary>
    ''' Specifies that, when this tender button is pressed, this EFT service should be used.
    ''' </summary>
    ''' <returns></returns>
    Property ExternalEFTService As clsHardwareItem.EFTAcquirerEnum

    ''' <summary>
    ''' This tender is currently active and available to use
    ''' </summary>
    ''' <returns></returns>
    Property Active As Boolean

    ''' <summary>
    ''' Some logic options that specify when the tender can and cannot be used/displayed.
    ''' </summary>
    ''' <returns></returns>
    Property MailOrderOptions As clsMailOrderOptions

    ''' <summary>
    ''' Determines if the operator can just press a Tender button without typing in the amount first.
    ''' </summary>
    ''' <returns></returns>
    Property MustEnterValue As Boolean

End Class

Public Class clsMailOrderOptions

    Enum SetMaxEnum

        ''' <summary>
        ''' Do not set a max value for this tender.
        ''' </summary>
        NoMax = 0

        ''' <summary>
        ''' The operator should not be able to tender more than the sum of mail order items + carriage value
        ''' </summary>
        ToMailOrderSum = 1

        ''' <summary>
        ''' The operator should not be able to tender more than the sum of non-mail order items
        ''' </summary>
        ToCarryOutSum = 2
    End Enum

    ''' <summary>
    ''' Some tenders should only be shown if there are Mail Order items in the basket. 
    ''' </summary>
    ''' <returns></returns>
    Property WhenMailOrderItemsPresent As FilterEnum = FilterEnum.Passive

    ''' <summary>
    '''  Specifies whether a Max value should be set for this tender
    ''' </summary>
    ''' <returns></returns>
    Property SetTenderMax As SetMaxEnum = SetMaxEnum.NoMax

End Class