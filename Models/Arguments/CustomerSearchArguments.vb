Imports System.ComponentModel.DataAnnotations

Public Class CustomerSearchArguments
    Implements iControllerArguments

    ''' <summary>
    ''' The customer's email address
    ''' </summary>
    ''' <returns></returns>
    <StringLength(100)>
    Public Property EmailAddress As String

    ''' <summary>
    ''' The Customer's name. The formatting of this can be controlled within the Eskimo software.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(250)>
    Public Property Name As String

    ''' <summary>
    ''' The main invoice address of the customer.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(400)>
    Public Property Address As String

    ''' <summary>
    ''' Post/Zip code for the customer's invoice address.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(16)>
    Public Property PostCode As String

    ''' <summary>
    ''' Company Name, if applicable
    ''' </summary>
    ''' <returns></returns>
    <StringLength(60)>
    Public Property CompanyName As String

    ''' <summary>
    ''' Customer's Contact Numbers. Will search both Telephone and Mobile fields.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(70)>
    Public Property Phone As String

    ''' <summary>
    ''' Will search both the Eskimo Customer ID and the External ID.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Public Property AccountID As String

End Class