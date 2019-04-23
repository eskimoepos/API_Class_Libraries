Imports System.ComponentModel.DataAnnotations
Imports EskimoClassLibraries

''' <summary>
''' The customer Class. Contains main address and contact information for a customer.
''' </summary>
Public Class clsCustomer
    Inherits EskimoBaseClass

    Implements IValidatableObject

    Public Const CustomerIDFormat As String = "\d{3}[-]\d{6}"
    Public Const CustomerLengthMsg As String = "The Eskimo Customer ID length must be 10 characters."


    ''' <summary>
    ''' The unique ID of the customer. This is in the format 000-000000 where the first three digits represent the Shop/Showroom code. This only needs to be specified when updating a record, not when creating.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Key>
    <StringLength(10, ErrorMessage:=clsCustomer.CustomerLengthMsg, MinimumLength:=10)>
    <RegularExpression(clsCustomer.CustomerIDFormat)>
    <ValidCustomer>
    Public Property ID As String

    ''' <summary>
    ''' Customer's first name(s)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(50)>
    Public Property Forename As String

    ''' <summary>
    ''' Customer's surname
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(50)>
    Public Property Surname As String

    ''' <summary>
    ''' The Company Name
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(60)>
    Public Property CompanyName As String


    Sub New(r As DataRecord)
        Dim intCustTitleID As Short?

        Try
            Me.ID = r("CustomerID")
            Me.ActiveAccount = r("AccountActive")

            Me.CompanyName = Nz(r("CustomerCompanyName"), Nothing, True)
            Me.EmailAddress = Nz(r("CustomerEmail"), Nothing, True)
            Me.Forename = Nz(r("CustomerContactName"), Nothing, True)
            Me.Mobile = Nz(r("CustomerMobile"), Nothing, True)
            Me.Notes = Nz(r("Notes"), Nothing, Nothing)
            Me.Surname = Nz(r("CustomerContactSurName"), Nothing, Nothing)
            Me.Telephone = Nz(r("CustomerTelephone"), Nothing, Nothing)
            Me.CountryCode = r("CustomerCountryISOCode")
            intCustTitleID = Nz(r("CusTitleID"), Nothing)
            Me.TitleID = intCustTitleID
            Me.ExternalID = Nz(r("ExternalID"), Nothing)

            If r("MultipleAddressesPerCustomer") AndAlso Not IsDBNull(r("AddressID")) Then
                Me.MainAddress = New clsAddress(r)
            End If

            If Not r("MultipleAddressesPerCustomer") Then
                Me.Address = Nz(r("Address"), Nothing, True)
                Me.PostCode = Nz(r("PostCode"), Nothing, True)
            End If

            Me.PriceLevel = r("DefaultPriceLevel")
            If Not IsDBNull(r("TradeCustomerPriceListID")) Then Me.PriceListID = CInt(r("TradeCustomerPriceListID"))
            Me.AutomaticDiscountPercentage = r("AutoDiscount")

        Catch ex As Exception
            Throw
        End Try


    End Sub


    'Private _PriceListID As Integer?
    'Private _PriceLevel As Integer
    'Private _AutomaticDiscountPercentage As Decimal

    ''' <summary>
    ''' Readonly. If using Price Lists, this determines which one the customer is linked to. See api/TillMenu/PriceListDump
    ''' </summary>
    ReadOnly Property PriceListID As Integer?
    '    Get
    '        Return _PriceListID
    '    End Get
    'End Property

    ''' <summary>
    ''' Readonly. If not using Price Lists, this determines which price level to use for the customer.
    ''' </summary>
    ReadOnly Property PriceLevel As Integer


    ''' <summary>
    ''' Readonly. Some customers are setup to benefit from a blanket discount on all products. This is the percentage
    ''' </summary>
    ReadOnly Property AutomaticDiscountPercentage As Integer

    '    Get
    '        Return _AutomaticDiscountPercentage
    '    End Get
    'End Property

    'Sub SetAutomaticDiscountPercentage(value As Decimal)
    '    _AutomaticDiscountPercentage = value
    'End Sub

    'Sub SetPriceLevel(value As Integer)
    '    _PriceLevel = value
    'End Sub

    'Sub SetPriceListID(value As Integer?)
    '    _PriceListID = value
    'End Sub

    Sub New(r As SqlClient.SqlDataReader)
        Me.New(New DataRecord(r))
    End Sub

    Sub New(r As DataRow)
        Me.New(New DataRecord(r))
    End Sub
    Sub New()

    End Sub

    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim lst As New List(Of ValidationResult)

        If (Me.LegacyAddressComponentsPopulated) AndAlso Me.MainAddress IsNot Nothing Then
            lst.Add(New ValidationResult("Address/PostCode cannot be populated along with MainAddress. If running an Eskimo system that supports multiple addresses per customer, then populate the MainAddress property, otherwise use the Address and PostCode fields."))
        End If

        Return lst.AsEnumerable
    End Function

    ''' <summary>
    ''' Any notes about the customer. These can also be edited in the Eskimo software so may NOT be suitable for presenting to end-users.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Notes As String

    ''' <summary>
    ''' Customer's telephone number
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(70)>
    Public Property Telephone As String

    ''' <summary>
    ''' Customer's mobile number
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(70)>
    Public Property Mobile As String

    ''' <summary>
    ''' The email address of the customer. This is not the unique identifier in the Eskimo software - there may be duplicates although you will not be able to insert a new customer if that email address already exists.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(100)>
    <EmailAddress>
    Public Property EmailAddress As String

    ''' <summary>
    ''' Current active status of the customer. (On/Off)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Public Property ActiveAccount As Boolean

    ''' <summary>
    ''' Customer's Address minus the postal code. Carriage returns can be specified in JSON with a simple \n (i.e. "Address": "123 High Street\nLondon"  )
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(400)>
    Public Property Address As String

    ''' <summary>
    ''' Customer's postal code
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(16)>
    Public Property PostCode As String

    ''' <summary>
    ''' ID of the Customer's title (i.e. Mr., Mrs., Ms.)   Use TitleID from api/Customers/Titles
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TitleID As Integer?

    ''' <summary>
    ''' The 2 digit country code, for United Kingdon, use GB http://www.worldatlas.com/aatlas/ctycodes.htm
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <StringLength(2, ErrorMessage:="The code must be 2 digits.", MinimumLength:=2)>
    <Required>
    Property CountryCode As String

    ''' <summary>
    ''' Non-Eskimo Identifier. If this customer has also been inserted into another CRM system or Website, this is the PK for this customer entry.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Property ExternalID As String

    ''' <summary>
    ''' Required if running a multiple-addresses per customer system. If running a single address per customer system, use the Address and Postcode fields.
    ''' </summary>
    ''' <returns></returns>
    Property MainAddress As clsAddress

    Function LegacyAddressComponentsPopulated() As Boolean
        Return Me.Address IsNot Nothing OrElse Me.PostCode IsNot Nothing
    End Function

End Class

