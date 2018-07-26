Public Class TaxCodeArguments
    Implements iControllerArguments

    Private _id As Integer = -1

    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

End Class
