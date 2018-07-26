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

End Class
