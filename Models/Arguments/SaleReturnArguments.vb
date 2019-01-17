Public Class SaleReturnArguments
    Implements iControllerArguments

    ''' <summary>
    ''' The reference of the original sale. If this originated from Eskimo, it will be in the format SSS-T-RRRRRR where S=Store Number, T=Till Number, R=Receipt Number
    ''' </summary>
    ''' <returns></returns>
    Property SaleReference As String

    ''' <summary>
    ''' Optional. Used mainly if scanning a gift receipt where only one of the lines from the original sale is present on the receipt.
    ''' </summary>
    ''' <returns></returns>
    Property Line As Integer?

End Class
