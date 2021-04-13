Imports System.ComponentModel.DataAnnotations

Public Class clsProductCode
    Inherits EskimoBaseClass

    ''' <summary>
    ''' A collection of barcoes for this product. The first one is the primary PLU number.
    ''' </summary>
    ''' <returns></returns>
    Property BarCodes As List(Of String)

    ''' <summary>
    ''' The description of the product
    ''' </summary>
    ''' <returns></returns>
    <StringLength(30)>
    Property Description As String

    ''' <summary>
    ''' The colour of the product, if applicable
    ''' </summary>
    ''' <returns></returns>
    Property Colour As String

    ''' <summary>
    ''' The size of the product, if applicable
    ''' </summary>
    ''' <returns></returns>
    Property Size As String

    ''' <summary>
    ''' When ordering from the suppplier, this is the number of products contained within a case. Many suppliers will only accept purchase orders by the case.
    ''' </summary>
    ''' <returns></returns>
    Property CaseQty As Integer

    ''' <summary>
    ''' The number of products contained within an inner. An inner is a box of products within a case that is delivered from the supplier.
    ''' </summary>
    ''' <returns></returns>
    Property InnerQty As Integer

End Class
