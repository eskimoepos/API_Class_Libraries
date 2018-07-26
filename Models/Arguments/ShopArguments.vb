
Public Class ShopArguments
    Implements iControllerArguments

    Private _ID As String

    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(ByVal prop_value As String)
            _ID = prop_value
        End Set
    End Property

End Class
