Imports System.ComponentModel.DataAnnotations

Public Class BarcodeArguments
    Implements iControllerArguments
    Implements ICloneable

    ''' <summary>
    ''' The barcode number scanned
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property Barcode As String

    ''' <summary>
    ''' The day of the month to start the query from
    ''' </summary>
    ''' <returns></returns>
    <Range(1, 31, ErrorMessage:="Vaid days are between 1 and 31")>
    <Required>
    Property StartDay As Integer

    ''' <summary>
    ''' The month of the year to start the query from
    ''' </summary>
    ''' <returns></returns>
    <Range(1, 12, ErrorMessage:="Vaid months are between 1 and 12")>
    <Required>
    Property StartMonth As Integer

    ''' <summary>
    ''' The day of the month to end the query from
    ''' </summary>
    ''' <returns></returns>
    <Range(1, 31, ErrorMessage:="Vaid days are between 1 and 31")>
    <Required>
    Property EndDay As Integer

    ''' <summary>
    ''' The month of the year to end the query from
    ''' </summary>
    ''' <returns></returns>
    <Range(1, 12, ErrorMessage:="Vaid months are between 1 and 12")>
    <Required>
    Property EndMonth As Integer

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class
