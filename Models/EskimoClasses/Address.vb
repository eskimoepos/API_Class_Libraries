Imports System.ComponentModel.DataAnnotations
Imports System.Data.SqlClient

Public Class clsAddress
    Inherits EskimoBaseClass

    Public Sub New()

    End Sub

    Sub New(r As SqlClient.SqlDataReader)
        Me.New(New DataRecord(r))
    End Sub

    Sub New(r As DataRow)
        Me.New(New DataRecord(r))
    End Sub

    Sub New(r As DataRecord)

        Me.Active = r("AddressActive")
        Me.Company = Nz(r("AddressCompany"), Nothing)
        Me.CountryCode = r("AddressCountryISOCode")
        Me.Line1 = Nz(r("AddressAddress1"), Nothing)
        Me.Line2 = Nz(r("AddressAddress2"), Nothing)
        Me.Line3 = Nz(r("AddressAddress3"), Nothing)
        Me.PostalTown = Nz(r("AddressPostalTown"), Nothing)
        Me.PostCode = Nz(r("AddressPostCode"), Nothing)
        Me.Region = Nz(r("AddressPostalCounty"), Nothing)

        '' also adjust clsAddressModel

    End Sub

    Sub PopulateCommandForDatabaseUpdate(ByRef cmd As SqlCommand, CustomerID As String, Ref As String, Inserting As Boolean)
        cmd.CommandText = "spAddressInsertUpdate"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlParameter("@CustomerID", CustomerID))
        cmd.Parameters.Add(New SqlParameter("@Ref", Ref))
        cmd.Parameters.Add(New SqlParameter("@Inserting", Inserting))
        cmd.Parameters.Add(New SqlParameter("@Company", Me.Company))
        cmd.Parameters.Add(New SqlParameter("@AddressLine1", Me.Line1))
        cmd.Parameters.Add(New SqlParameter("@AddressLine2", Me.Line2))
        cmd.Parameters.Add(New SqlParameter("@AddressLine3", Me.Line3))
        cmd.Parameters.Add(New SqlParameter("@Town", Me.PostalTown))
        cmd.Parameters.Add(New SqlParameter("@County", Me.Region))
        cmd.Parameters.Add(New SqlParameter("@PostCode", Me.PostCode))
        cmd.Parameters.Add(New SqlParameter("@Active", Me.Active))
        cmd.Parameters.Add(New SqlParameter("@CountryCode", Me.CountryCode))
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        If Not TypeOf (obj) Is clsAddress Then
            Return False
        End If

        Dim addr As clsAddress = obj

        If FieldDifferent(Me.Active, addr.Active) Then Return False
        If FieldDifferent(Me.Company, addr.Company) Then Return False
        If FieldDifferent(Me.CountryCode, addr.CountryCode) Then Return False
        If FieldDifferent(Me.Line1, addr.Line1) Then Return False
        If FieldDifferent(Me.Line2, addr.Line2) Then Return False
        If FieldDifferent(Me.Line3, addr.Line3) Then Return False
        If FieldDifferent(Me.PostalTown, addr.PostalTown) Then Return False
        If FieldDifferent(Me.PostCode, addr.PostCode) Then Return False
        If FieldDifferent(Me.Region, addr.Region) Then Return False

        Return True

    End Function

    Private Function FieldDifferent(local_field As String, foreign_field As String) As Boolean
        If local_field Is Nothing AndAlso Not foreign_field Is Nothing Then Return True
        If Not local_field Is Nothing AndAlso foreign_field Is Nothing Then Return True
        Return local_field <> foreign_field
    End Function

    Private Function FieldDifferent(local_field As Boolean, foreign_field As Boolean) As Boolean
        Return local_field <> foreign_field
    End Function


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

