Public Class clsCustomerFeed
    Inherits clsCustomer



    ReadOnly Property FullName As String
        Get
            Dim strName As String = Nothing

            If Me.Forename IsNot Nothing AndAlso Me.Forename <> "" Then
                strName = Me.Forename
            End If

            If Me.Surname IsNot Nothing AndAlso Me.Surname <> "" Then
                If strName IsNot Nothing Then strName += " "
                strName += Me.Surname
            End If
            Return strName

        End Get
    End Property



End Class
