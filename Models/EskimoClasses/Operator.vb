Imports System.ComponentModel.DataAnnotations

Public Class clsOperator

    Inherits EskimoBaseClass

    Enum OperatorGenderEnum
        Male = 0
        Female = 1
    End Enum

    ''' <summary>
    ''' The Eskimo ID of the Operator. 
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(12)>
    Property ID As String

    ''' <summary>
    ''' The operator's name
    ''' </summary>
    ''' <returns></returns>
    <StringLength(20)>
    Property Name As String

    ''' <summary>
    ''' Their working status.
    ''' </summary>
    ''' <returns></returns>
    Property Active As Boolean

    ''' <summary>
    ''' Specifies if this person roams between sites (like any area manager for example)
    ''' </summary>
    ''' <returns></returns>
    Property RoamingOperator As Boolean

    ''' <summary>
    ''' Specifies if this person has administrative rights
    ''' </summary>
    ''' <returns></returns>
    Property Administrator As Boolean

    ''' <summary>
    ''' The operator's gender
    ''' </summary>
    ''' <returns></returns>
    Property Gender As OperatorGenderEnum

    ''' <summary>
    ''' The operator's password to log on to the EPOS software. Contact Eskimo EPOS for info on obtaining the decryption key.
    ''' </summary>
    ''' <returns></returns>
    Property EncryptedPassword As String

    ''' <summary>
    ''' A list of all things this operator is allowed to do. (Only populated if the PermissionRequirements field is passed in the request).
    ''' </summary>
    ''' <returns></returns>
    Property Permissions As List(Of clsOperatorPermission)

End Class

Public Class clsOperatorPermission
    Enum PermissionAdditionalResponseTypeEnum
        NoAdditional = 1
        DatabaseLink = 2
        FreeText = 3
        ReportingCategoryID = 4
        ReportingReportID = 5
    End Enum
    Property PermID As Integer
    Property AdditionalResponseType As PermissionAdditionalResponseTypeEnum
    Property PermDescription As String
    Property Value As String
End Class
