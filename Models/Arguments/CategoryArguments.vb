
Public Class CategoryArguments
    Implements iControllerArguments

    Private _parentID As String
    Private _ID As String

    Public Property Eskimo_Parent_ID() As String
        Get
            Return _parentID
        End Get
        Set(ByVal prop_value As String)
            _parentID = prop_value
        End Set
    End Property

    Public Property Eskimo_ID() As String
        Get
            Return _ID
        End Get
        Set(ByVal prop_value As String)
            _ID = prop_value
        End Set
    End Property
End Class
