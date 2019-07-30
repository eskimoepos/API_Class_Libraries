Imports System.ComponentModel.DataAnnotations
Public Class clsMarketingFlag

    ''' <summary>
    ''' ID and DB Primary Key of the Flag
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property ID As Integer

    ''' <summary>
    ''' Name of the marketing flag to display to the operator in the UI.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(150)>
    Property Description As String

    ''' <summary>
    ''' Extended Description that gives a more detailed explaination about what this options means in practice.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(3000)>
    Property ExtDescription As String

    ''' <summary>
    ''' An array of sub-options for this flag.
    ''' </summary>
    ''' <returns></returns>
    Property Children As List(Of clsMarketingFlag)

    ''' <summary>
    ''' Controls how the flag should be displayed in the UI
    ''' </summary>
    ''' <returns></returns>
    <EnumDataType(GetType(FlagTypeEnum))>
    Property FlagType As FlagTypeEnum

    ''' <summary>
    ''' Determines if the flag is active and should be displayed in the UI
    ''' </summary>
    ''' <returns></returns>
    Property Active As Boolean

    ''' <summary>
    ''' The default state of the flag
    ''' </summary>
    ''' <returns></returns>
    Property DefaultValue As Boolean

    ''' <summary>
    ''' Determines the order in which to display the items in the UI
    ''' </summary>
    ''' <returns></returns>
    Property OrderBy As Integer

    Enum FlagTypeEnum
        ''' <summary>
        ''' This is just a group header, usually the parent of other flags
        ''' </summary>
        HeaderOnly = 0

        ''' <summary>
        ''' A checkbox control with the name of the flag beside it
        ''' </summary>
        Checkbox = 1

        ''' <summary>
        ''' A radio button (or option button) control with the name of the flag beside it. As radio buttons are clicked, other radio buttons flags within the same group are deselected (or set to false). https://www.w3schools.com/tags/att_input_type_radio.asp
        ''' </summary>
        RadioButton = 2
    End Enum

End Class
