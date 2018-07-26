''' <summary>
''' A class providing information about the products that can be counted. Also included is a list of the operators that can sign in
''' </summary>
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
    ''' A collection of all products on file. if more than one barcode is supplied, the first one is the main PLU number.
    ''' </summary>
    ''' <returns></returns>
    Property Products As List(Of clsProductCode)

    ''' <summary>
    ''' A collection of operators that work at this showroom.
    ''' </summary>
    ''' <returns></returns>
    Property Operators As List(Of clsOperator)

End Class
