Imports System.ComponentModel.DataAnnotations

''' <summary>
''' The Barcode Action Class. Contains information about a job to be queued. i.e. A barcode to be printed, stock increment to be performed
''' </summary>
Public Class clsBarcodeAction
    Inherits EskimoBaseClass

    Enum ActionTypeEnum

        ''' <summary>
        ''' Flag item to be ordered on the next purchase order to the supplier.
        ''' </summary>
        FlagForOrder = 0

        ''' <summary>
        ''' Print out a barcode label for this barcode
        ''' </summary>
        PrintBarcode = 1

        ''' <summary>
        ''' Record this barcode to be used on a stock inward in the back office software
        ''' </summary>
        StockInward = 2
    End Enum

    ''' <summary>
    ''' The barcode scanned
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property BarcodeScanned As String

    ''' <summary>
    ''' The action quantity
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property Qty As Integer

    ''' <summary>
    ''' The type of action to be performed
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property ActionType As ActionTypeEnum

    ''' <summary>
    ''' The ID of the operator using the handheld device.
    ''' </summary>
    ''' <returns></returns>
    Property OperatorID As String

    ''' <summary>
    ''' Any important notes about the action
    ''' </summary>
    ''' <returns></returns>
    Property Notes As String = ""

    ''' <summary>
    ''' If the product was 'not on file' then the description must be included so that the product can be added later.
    ''' </summary>
    ''' <returns></returns>
    Property ProductDescription As String = ""

End Class
