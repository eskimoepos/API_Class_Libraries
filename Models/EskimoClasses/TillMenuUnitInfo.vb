Imports System.ComponentModel.DataAnnotations

Public Class clsTillMenuUnitInfo
    Inherits EskimoBaseClass

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

    Property DefaultInvoiceLayout As Integer = 1

    Property SKUCount As Long

    ''' <summary>
    ''' The next receipt number to use for sales. Used mainly when in offline mode.
    ''' </summary>
    ''' <returns></returns>
    Property NextReceiptNumber As Integer

    ''' <summary>
    ''' A collection of till hardware models relevant for this particular till.
    ''' </summary>
    ''' <returns></returns>
    Property HardwareModels As IEnumerable(Of clsHardwareModel)

    ''' <summary>
    ''' A collection of till hardware that is connected to this particular till.
    ''' </summary>
    ''' <returns></returns>
    Property Hardware As IEnumerable(Of clsHardwareItem)
    Property ReceiptHeaders As IEnumerable(Of clsReceiptMargin)
    Property ReceiptFooters As IEnumerable(Of clsReceiptMargin)

End Class
