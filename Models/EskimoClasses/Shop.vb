Imports System.ComponentModel.DataAnnotations
''' <summary>
''' The Shop Class. This contains information about the site/showrooms including address and contact information.
''' </summary>
Public Class clsShop

    Inherits EskimoBaseClass

    Private _concession As Boolean
    Private _status As String
    Private _name As String
    Private _code As String
    Private _address1 As String
    Private _address2 As String
    Private _address3 As String
    Private _address4 As String
    Private _postCode As String
    Private _telephone As String
    Private _fax As String
    Private _email As String

    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal prop_value As String)
            _name = prop_value
        End Set
    End Property

    <Key>
    <StringLength(3, ErrorMessage:="The code must be 3 digits.", MinimumLength:=3)> _
    Public Property Code() As String
        Get
            Return _code
        End Get
        Set(ByVal prop_value As String)
            _code = prop_value
        End Set
    End Property

    Public Property Address1() As String
        Get
            Return _address1
        End Get
        Set(ByVal prop_value As String)
            _address1 = prop_value
        End Set
    End Property

    Public Property Address2() As String
        Get
            Return _address2
        End Get
        Set(ByVal prop_value As String)
            _address2 = prop_value
        End Set
    End Property

    Public Property Address3() As String
        Get
            Return _address3
        End Get
        Set(ByVal prop_value As String)
            _address3 = prop_value
        End Set
    End Property

    Public Property Address4() As String
        Get
            Return _address4
        End Get
        Set(ByVal prop_value As String)
            _address4 = prop_value
        End Set
    End Property

    Public Property PostCode() As String
        Get
            Return _postCode
        End Get
        Set(ByVal prop_value As String)
            _postCode = prop_value
        End Set
    End Property

    Public Property Telephone() As String
        Get
            Return _telephone
        End Get
        Set(ByVal prop_value As String)
            _telephone = prop_value
        End Set
    End Property

    Public Property Fax() As String
        Get
            Return _fax
        End Get
        Set(ByVal prop_value As String)
            _fax = prop_value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal prop_value As String)
            _email = prop_value
        End Set
    End Property

    Public Property Concession() As Boolean
        Get
            Return _concession
        End Get
        Set(ByVal prop_value As Boolean)
            _concession = prop_value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal prop_value As String)
            _status = prop_value
        End Set
    End Property

End Class
