Public Class clsReceiptOptions

    ''' <summary>
    ''' The next receipt number to use for sales. Used mainly when in offline mode.
    ''' </summary>
    ''' <returns></returns>
    Property NextReceiptNumber As Integer
    Property DefaultInvoiceLayout As Integer = 1
    ''' <summary>
    ''' Determines if the switch to print a receipt is on by default at the end of a sale.
    ''' </summary>
    ''' <returns></returns>
    Property AutoPrintReceipt As Boolean

    Property ReceiptHeaders As IEnumerable(Of clsReceiptMargin)
    Property ReceiptFooters As IEnumerable(Of clsReceiptMargin)

End Class
