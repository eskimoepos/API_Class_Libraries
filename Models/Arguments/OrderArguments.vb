Imports System.ComponentModel.DataAnnotations
Imports System.Reflection

Public Class OrderArguments
    Inherits GetOrdersArguments

    Implements iControllerArguments

    Public Property ID As String

    Sub New()

    End Sub
    Sub New(search_data As GetOrdersArguments)
        MyBase.New

        Dim type = search_data.GetType
        'Dim instance = Activator.CreateInstance(type)
        Dim properties As PropertyInfo() = type.GetProperties()
        For Each [property] In properties
            [property].SetValue(Me, [property].GetValue(search_data, Nothing), Nothing)
        Next

        Me.FromSearch = True

    End Sub

    Public ReadOnly Property FromSearch As Boolean

End Class
