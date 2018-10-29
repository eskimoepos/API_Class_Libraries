Public Class clsReceiptOptions

    ''' <summary>
    ''' The next receipt number to use for sales. Used mainly when in offline mode.
    ''' </summary>
    ''' <returns></returns>
    Property NextReceiptNumber As Integer
    Property DefaultInvoiceLayout As Integer = 1
    ''' <summary>
    ''' Determines if the switch to print a till receipt is on by default at the end of a sale.
    ''' </summary>
    ''' <returns></returns>
    Property AutoPrintReceipt As Boolean
    ''' <summary>
    ''' Determines if the switch to print an A4 receipt/invoice is on by default at the end of a sale.
    ''' </summary>
    ''' <returns></returns>
    Property AutoPrintA4Receipt As Boolean
    ''' <summary>
    ''' Determines if the switch to email the customer their receipt is on by default at the end of a sale.
    ''' </summary>
    ''' <returns></returns>
    Property AutoEmailReceipt As Boolean
    Property ReceiptHeaders As IEnumerable(Of clsReceiptMargin)
    Property ReceiptFooters As IEnumerable(Of clsReceiptMargin)
    Property ShowConfirmationPopup As Boolean
End Class
