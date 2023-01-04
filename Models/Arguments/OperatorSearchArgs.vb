Imports System.ComponentModel.DataAnnotations

Public Class OperatorArguments
    Implements iControllerArguments

    ''' <summary>
    ''' Optional. Can return only Male Operators, or only Female one. 
    ''' </summary>
    ''' <returns></returns>
    Property Gender As clsOperator.OperatorGenderEnum?

    ''' <summary>
    ''' Specifies whether the operators are active (still working for the business or not). Most of the time, this will be 1.
    ''' </summary>
    ''' <returns></returns>
    <EnumDataType(GetType(FilterEnum))>
    <Required>
    Property Active As FilterEnum

    ''' <summary>
    ''' Filters Roaming Operators (Regional Managers that look after multiple sites)
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <EnumDataType(GetType(FilterEnum))>
    Property RegionalManagers As FilterEnum

    ''' <summary>
    ''' Optional. Can filter by the Operator Name. Percentage characters can be used for wildcard searches
    ''' </summary>
    ''' <returns></returns>
    <StringLength(25)>
    Property Name As String

    <StringLength(3, ErrorMessage:="The StoreNumber must be 3 digits.", MinimumLength:=3)>
    Property StoreNumber As String

    ''' <summary>
    ''' If populated, then an array of permissions that the user is allowed to perform will be returned. The results will be related to the ApplicationID passed in.
    ''' </summary>
    ''' <returns></returns>
    Property PermissionRequirements As clsOperatorPermissionArgs

    Enum PasswordEncryptionEngineEnum
        MD5 = 1
        BCrypt = 2
    End Enum

    ''' <summary>
    ''' The password field that is returned will be encrypted. This denotes the engine that will be used to perform this.
    ''' </summary>
    ''' <returns></returns>
    Property PasswordEncryptionEngine As PasswordEncryptionEngineEnum = PasswordEncryptionEngineEnum.MD5

End Class
