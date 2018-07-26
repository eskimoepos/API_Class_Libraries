Public Class ListingArgumentsEx
    Inherits ListingsArguments

    Property ConnID As Integer

    Sub New(obj As ListingsArguments)
        MyBase.New

        MyBase.ListingFIlter = obj.ListingFIlter
    End Sub
End Class
