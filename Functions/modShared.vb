Public Module modShared

    ''' <summary>
    ''' Converts database nulls to a default value passed in
    ''' </summary>
    ''' <param name="input"></param>
    ''' <param name="def"></param>
    ''' <returns></returns>
    Public Function Nz(input As Object, def As Object) As Object
        If input Is Nothing OrElse IsDBNull(input) Then
            Return def
        Else
            Return input
        End If
    End Function

    Public Function Nz(input As Object, def As Object, SetNullStringsToNull As Boolean) As String
        If IsDBNull(input) Then
            Return def
        Else
            If Not input Is Nothing Then
                If input.ToString.Trim = "" AndAlso SetNullStringsToNull Then Return Nothing
            End If
            Return input
        End If
    End Function
End Module
