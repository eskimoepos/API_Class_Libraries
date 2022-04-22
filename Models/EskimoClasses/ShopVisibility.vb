Imports System.ComponentModel.DataAnnotations

Public Class clsShopVisibility
    Implements IValidatableObject

    Public VisibleEverywhere As Boolean

    Sub New()
        'Stop
    End Sub

    Sub New(val As DBNull)
        Me.New(String.Empty)
    End Sub

    Sub New(strInput As String)
        If Not String.IsNullOrEmpty(strInput) Then
            If strInput.ToUpper.Equals("ALL") Then
                VisibleEverywhere = True
            Else
                Dim IDs As List(Of String)

                IDs = Strings.Split(strInput, "|").ToList.Where(Function(x) x.Length = 3).ToList
                ShopIDs = IDs.OrderBy(Function(x) Convert.ToInt32(x)).ToList
            End If
        End If
    End Sub

    <StringLengthList(3)>
    Public ShopIDs As New List(Of String)
    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim lst As New List(Of ValidationResult)

        If ShopIDs IsNot Nothing AndAlso ShopIDs.Any And VisibleEverywhere Then
            lst.Add(New ValidationResult("If VisibileEverywhere is true, there is no need to pass any Shop IDs"))
        End If

        If Not VisibleEverywhere AndAlso ShopIDs IsNot Nothing AndAlso ShopIDs.Any Then
            For Each itm In ShopIDs.Where(Function(x) Not IsNumeric(x) OrElse x.Length <> 3)
                lst.Add(New ValidationResult($"Visible Shop IDs must be numeric and three characters long (i.e. 010). Failing entry: {itm}"))
            Next
        End If

        Return lst

    End Function

    Public Overrides Function ToString() As String

        If Me.VisibleEverywhere Then
            Return "ALL"
        Else
            Return String.Join("|", ShopIDs.OrderBy(Function(x) Convert.ToInt32(x)))
        End If

    End Function

End Class
