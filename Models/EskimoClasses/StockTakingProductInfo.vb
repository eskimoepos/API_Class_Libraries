
Public Class clsStockTakingProductInfo
    Inherits EskimoBaseClass

    ''' <summary>
    ''' The name of the location 1. i.e. Shop Floor
    ''' </summary>
    ''' <returns></returns>
    Property Location1Name As String

    ''' <summary>
    ''' The name of the location 2. i.e. Second Floor
    ''' </summary>
    ''' <returns></returns>
    Property Location2Name As String

    ''' <summary>
    ''' The name of the location 3. i.e. Garage Lock-up
    ''' </summary>
    ''' <returns></returns>
    Property Location3Name As String

    ''' <summary>
    ''' The Eskimo must be put into Stock Take mode before stock can be counted in the stock take. This property states whether this has been performed in the back office software or not.
    ''' </summary>
    ''' <returns></returns>
    Property InStockTakeMode As Boolean?

    ''' <summary>
    ''' If the system has been put into Stock Take mode, this property states the date when this happened. This can also act as a safety net, to make sure it has not been left in Stock Take mode since a previous stock take.
    ''' </summary>
    ''' <returns></returns>
    Property StockTakeCommenced As Date?

    '''' <summary>
    '''' A collection of all products on file. if more than one barcode is supplied, the first one is the main PLU number.
    '''' </summary>
    '''' <returns></returns>
    'Property Products As List(Of clsProductCode)

    ''' <summary>
    ''' A collection of operators that work at this showroom.
    ''' </summary>
    ''' <returns></returns>
    Property Operators As List(Of clsOperator)

End Class
