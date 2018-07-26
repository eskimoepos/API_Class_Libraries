Imports System.ComponentModel.DataAnnotations

Public Class clsAddress
    Inherits EskimoBaseClass

    Public Sub New()

    End Sub

    Sub New(r As DataRow)

        Me.Active = r("AddressActive")
        Me.Company = Nz(r("AddressCompany"), Nothing)
        Me.CountryCode = r("AddressCountryCode")
        Me.Line1 = Nz(r("AddressAddress1"), Nothing)
        Me.Line2 = Nz(r("AddressAddress2"), Nothing)
        Me.Line3 = Nz(r("AddressAddress3"), Nothing)
        Me.PostalTown = Nz(r("AddressPostalTown"), Nothing)
        Me.PostCode = Nz(r("AddressPostCode"), Nothing)
        Me.Region = Nz(r("AddressPostalCounty"), Nothing)

    End Sub

    ''' <summary>
    ''' Optional. Name of the company / organisation.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Property Company As String

    ''' <summary>
    ''' Optional. The first line of the address i.e. Flat 173
    ''' </summary>
    ''' <returns></returns>
    <StringLength(256)>
    Property Line1 As String

    ''' <summary>
    ''' Optional. The second line of the address i.e. Mulberry House
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Property Line2 As String

    ''' <summary>
    ''' The third line of the address
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Property Line3 As String

    ''' <summary>
    ''' The postal town or city. i.e. London
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Property PostalTown As String

    ''' <summary>
    ''' The county or state i.e. Dorset or California
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Property Region As String

    ''' <summary>
    ''' The postal or zip code.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(20)>
    Property PostCode As String

    ''' <summary>
    ''' The 2 digit country code, for United Kingdom, use GB http://www.worldatlas.com/aatlas/ctycodes.htm
    ''' </summary>
    ''' <returns></returns>
    <StringLength(2, ErrorMessage:="Country code must be 2 digits in length.", MinimumLength:=2)>
    <Required>
    Property CountryCode As String

    ''' <summary>
    ''' If the address is active (in use). Defaults to True if not passed.
    ''' </summary>
    ''' <returns></returns>
    Property Active As Boolean = True

End Class

