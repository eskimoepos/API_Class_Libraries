Imports System.ComponentModel.DataAnnotations
''' <summary>
''' The Shop Class. This contains information about the site/showrooms including address and contact information.
''' </summary>
Public Class clsShop

    Inherits EskimoBaseClass

    ''' <summary>
    ''' The friendly name of the shop
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Public Property Name As String

    ''' <summary>
    ''' A unique three digit string to identify the shop.
    ''' </summary>
    ''' <returns></returns>
    <Key>
    <StringLength(3, ErrorMessage:="The code must be 3 digits.", MinimumLength:=3)>
    Public Property Code As String

    ''' <summary>
    ''' The first address line
    ''' </summary>
    ''' <returns></returns>
    <StringLength(250)>
    Public Property Address1 As String

    ''' <summary>
    ''' The second address line
    ''' </summary>
    ''' <returns></returns>
    <StringLength(250)>
    Public Property Address2 As String

    ''' <summary>
    ''' The third address line
    ''' </summary>
    ''' <returns></returns>
    <StringLength(250)>
    Public Property Address3 As String

    ''' <summary>
    ''' The fourth address line
    ''' </summary>
    ''' <returns></returns>
    <StringLength(250)>
    Public Property Address4 As String

    ''' <summary>
    ''' The shop's postcode
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Public Property PostCode As String

    ''' <summary>
    ''' The main telephone number for the shop
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Public Property Telephone As String

    ''' <summary>
    ''' Do people still use these? Well, if they do, this is the facsimile number for the shop.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Public Property Fax As String

    ''' <summary>
    ''' The email address for the shop
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Public Property Email As String

    ''' <summary>
    ''' Determines if the unit is actually a concession - perhaps within a large department store
    ''' </summary>
    ''' <returns></returns>
    Public Property Concession As Boolean

    ''' <summary>
    ''' The status of the shop. 
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Public Property Status As String

    ''' <summary>
    ''' The area or region that the shop is in - controlled by the retailer.
    ''' </summary>
    ''' <returns></returns>
    Public Property RegionId As Integer
End Class
