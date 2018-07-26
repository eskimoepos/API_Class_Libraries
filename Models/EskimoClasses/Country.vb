Imports System.ComponentModel.DataAnnotations

''' <summary>
''' The Country Class. Contains Country information
''' </summary>
Public Class clsCountry
    Inherits EskimoBaseClass

    ''' <summary>
    ''' The numeric ID of the Country as generated from Eskimo
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property EskimoCountryID As Integer

    <StringLength(50)>
    <Required>
    Property CountryName As String

    <StringLength(2, ErrorMessage:="The ISO code is 2 digits", MinimumLength:=2)>
    <Required>
    Property ISOCode As String

End Class
