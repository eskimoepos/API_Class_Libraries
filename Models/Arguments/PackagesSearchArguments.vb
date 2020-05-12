Imports System.ComponentModel.DataAnnotations

Public Class PackagesSearchArguments
    Implements iControllerArguments

    ''' <summary>
    ''' Optional. Search for a particular package. Pass the identifier from the api/Products/All results
    ''' </summary>
    ''' <returns></returns>
    Property eskimo_product_identifier As String

End Class
