Imports System.ComponentModel.DataAnnotations

Public Class clsProductGroup

    Implements IValidatableObject

    Enum GroupingLevelEnum
        GroupLevel = 1
        DepartmentLevel = 2
    End Enum

    ''' <summary>
    ''' Unique ID per grouping level - so there can be two IDs of 5 - one in Grouping Level 1 and another in 2.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property ID As Integer

    ''' <summary>
    ''' The nest-level within the hierarchy. Groups contains an array of Departments underneath.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <EnumDataType(GetType(GroupingLevelEnum))>
    Property GroupingLevel As GroupingLevelEnum

    <Required>
    <StringLength(50)>
    Property InternalDescription As String

    <StringLength(50)>
    Property WebTitle As String

    <StringLength(4000)>
    Property WebDescription As String

    ''' <summary>
    ''' Only applicable where the GroupingLevel = Department. This links to the ID of the Group above.
    ''' </summary>
    ''' <returns></returns>
    Property ParentID As Integer?

    ''' <summary>
    ''' The order in which the groups appear when displayed in lists
    ''' </summary>
    ''' <returns></returns>
    Property OrderBy As Integer

    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim lst As New List(Of ValidationResult)

        Select Case Me.GroupingLevel
            Case GroupingLevelEnum.GroupLevel
                If ParentID IsNot Nothing Then
                    lst.Add(New ValidationResult("The ParentID cannot be passed for Group Level entries as they are the top-level categories."))
                End If
            Case GroupingLevelEnum.DepartmentLevel
                If ParentID Is Nothing Then
                    lst.Add(New ValidationResult("The ParentID cannot be null for Department Level entries"))
                End If
        End Select

        Return lst
    End Function

End Class