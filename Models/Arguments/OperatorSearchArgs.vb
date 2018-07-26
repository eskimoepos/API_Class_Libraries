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

End Class
