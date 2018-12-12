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
    ''' Controls is the cash drawer is to be fired at the completion of the sale when this tender method is used.
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
End Class
