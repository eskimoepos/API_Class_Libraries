Imports System.ComponentModel.DataAnnotations

Public Class clsSKUAttribute
    Property Id As Integer
    Property Name As String
    Property VisibleToEndUsers As Boolean
    Property OrderBy As Integer
    Property Active As Boolean
    Property Values As List(Of clsSKUAttributeValue)
End Class

Public Class clsSKUAttributeValue
    Property Id As Integer
    Property Value As String
    Property OrderBy As Integer
    Property Active As Boolean
End Class

Public Class clsSKUAttributeLink
    Property Id As Integer
    Property AttributeValueId As Integer
    Property AttributeId As Integer
    Property Active As Boolean
End Class
