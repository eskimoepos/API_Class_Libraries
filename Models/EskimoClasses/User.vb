Imports System.ComponentModel.DataAnnotations

Public Class clsUser
    <Required>
    <EmailAddress>
    Property email As String
    Property id As String
    Property shop_connections As New List(Of String)
    Property eskimo_operator_id As String
End Class

Class clsAppPermission
    Property PermissionDescription As String


End Class