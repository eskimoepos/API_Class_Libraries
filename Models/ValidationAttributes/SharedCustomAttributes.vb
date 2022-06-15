Imports System.ComponentModel.DataAnnotations

Public Class StringLengthListAttribute
    Inherits StringLengthAttribute

    Public Overrides Function IsValid(value As Object) As Boolean

        If value Is Nothing Then Return True

        If Not value.GetType = GetType(List(Of String)) Then
            Return False
        End If

        For Each strItem In TryCast(value, List(Of String))
            If strItem.Length > MaximumLength OrElse strItem.Length < MinimumLength Then Return False
        Next

        Return True

    End Function

    Public Overrides Function FormatErrorMessage(name As String) As String

        Return $"The field {name} contains entries that are longer than {Me.MaximumLength} characters in length"

    End Function

    Public Sub New(ByVal maximumLength As Integer)
        MyBase.New(maximumLength)
    End Sub

End Class

<AttributeUsage(AttributeTargets.Parameter Or AttributeTargets.Field Or AttributeTargets.[Property] Or AttributeTargets.Method, AllowMultiple:=False)>
Public NotInheritable Class EnumDataTypeArrayAttribute
    Inherits DataTypeAttribute

    Public Sub New(ByVal enumType As Type)
        MyBase.New("Enumeration")

        If enumType Is Nothing Then
            Throw New InvalidOperationException("Type cannot be null")
        End If

        If Not enumType.IsEnum Then
            Throw New InvalidOperationException("Type must be an enum")
        End If

        Me.EnumType = enumType
    End Sub

    Public Overrides Function IsValid(ByVal value As Object) As Boolean
        If value Is Nothing Then Return True
        Dim at = value.[GetType]()
        If Not at.IsArray Then Return False
        Dim t = at.GetElementType()
        If t <> Me.EnumType Then Return False

        For Each v In TryCast(value, Array)
            If Not [Enum].IsDefined(Me.EnumType, v) Then
                Return False
            End If
        Next

        Return True
    End Function

    Public Property EnumType As Type
End Class
