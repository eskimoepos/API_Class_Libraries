Imports System.ComponentModel.DataAnnotations
''' <summary>
''' The Tax (VAT) Code Class
''' </summary>
Public Class clsTaxCode

    Inherits EskimoBaseClass

    Private _taxID As Integer
    Private _taxDescription As String
    Private _taxRate As Decimal

    ''' <summary>
    ''' The Eskimo ID 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Public Property TaxID() As Integer
        Get
            Return _taxID
        End Get
        Set(ByVal prop_value As Integer)
            _taxID = prop_value
        End Set
    End Property

    ''' <summary>
    ''' A short Description of the Rate. i.e. Zero Rated, Standard Rate, Exempt.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TaxDescription() As String
        Get
            Return _taxDescription
        End Get
        Set(ByVal prop_value As String)
            _taxDescription = prop_value
        End Set
    End Property

    ''' <summary>
    ''' The Tax Rate as a percentage i.e. 17.5 or 20.0
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TaxRate() As Decimal
        Get
            Return _taxRate
        End Get
        Set(ByVal prop_value As Decimal)
            _taxRate = prop_value
        End Set
    End Property

End Class
