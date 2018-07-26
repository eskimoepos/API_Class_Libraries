Public Module modShared

    ''' <summary>
    ''' Converts database nulls to a default value passed in
    ''' </summary>
    ''' <param name="input"></param>
    ''' <param name="def"></param>
    ''' <returns></returns>
    Public Function Nz(input As Object, def As Object) As Object
        If IsDBNull(input) Then
            Return def
        Else
            Return input
        End If
    End Function

End Module
