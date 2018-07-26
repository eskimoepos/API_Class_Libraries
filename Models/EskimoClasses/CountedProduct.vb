Imports System.ComponentModel.DataAnnotations

''' <summary>
''' A class representing one barcode that has been counted
''' </summary>
Public Class clsCountedProduct

    Inherits EskimoBaseClass
    Implements ICloneable

    Public Sub New()
        Dim g As Guid = Guid.NewGuid
        Me.ScanID = g.ToString
    End Sub

    ''' <summary>
    ''' The date/time the barcode was scanned. This may be different to the time the entry is added to the database by a few minutes if the api call fails initially.
    ''' </summary>
    ''' <returns></returns>
    Property DateScanned As DateTime = Now

    ''' <summary>
    ''' A unique identifier for this row. Feel free to use your own identifier. This can aid to correlate results when the response is received.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Property ScanID As String

    ''' <summary>
    ''' Must be a valid PLU code
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(35)>
    Property PLU As String

    ''' <summary>
    ''' The number of pieces that have been counted for this PLU. Multiple rows for the same PLU can be present.
    ''' </summary>
    ''' <returns></returns>
    Property CountAmount As Integer

    ''' <summary>
    ''' The Eskimo system manages stock in up to 3 stock locations. This specifies which location has been counted for this product.
    ''' </summary>
    ''' <returns></returns>
    <Range(1, 3, ErrorMessage:="Stock Location must be between 1 and 3")>
    Property Location As Integer = 1

    ''' <summary>
    ''' Optional. The location on the shelf where this product can be found. Useful in warehouse racking etc.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Property ShelfLocation As String = ""

    ''' <summary>
    ''' Must match an existing Eskimo Operator ID. These are retieved by calling the StockTaking/GetProductData call
    ''' </summary>
    ''' <returns></returns>
    <StringLength(12)>
    <Required>
    Property OperatorID As String

    ''' <summary>
    ''' Pass any notes you like about this count. Some people like to pass the friendly name of the device (i.e. Scanner 5 or Bob's)
    ''' </summary>
    ''' <returns></returns>
    <StringLength(200)>
    Property AdditionalInfo As String

    ''' <summary>
    ''' The Stock Area (or room) that is being counted. A free-text, friendly name. For example, useful in a busines that has many different demonstration living rooms. This can filtered on when Validating the Stock Take.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(100)>
    Property Area As String


    ''' <summary>
    ''' The unique hardware ID of the device being to used. This can filtered on when Validating the Stock Take.
    ''' </summary>
    ''' <returns></returns>
    Property DeviceID As String

    ''' <summary>
    ''' The count value after incrementing. This does not need to be passed in the Request. It will be returned in the response.
    ''' </summary>
    ''' <returns></returns>
    Property CurrentLevel As Integer

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class

Public Class clsCountedProducts

    Inherits EskimoBaseClass

    ''' <summary>
    ''' A collection of products that have been counted
    ''' </summary>
    ''' <returns></returns>
    Property Counts As New List(Of clsCountedProduct)


End Class