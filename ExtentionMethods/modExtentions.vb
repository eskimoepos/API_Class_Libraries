Imports System.Runtime.CompilerServices

Public Module modExtentions
    <Extension()>
    Public Function AsMoney(ByVal dInput As Decimal) As String
        Return String.Format("{0:C}", dInput)
    End Function

    ''' <summary>
    ''' For 20% VAT, pass 1.2 
    ''' </summary>
    ''' <param name="dInput"></param>
    ''' <param name="Rate"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function MakeNet(ByVal dInput As Decimal, Rate As Decimal) As Decimal
        Return dInput / Rate
    End Function

    <Extension()>
    Public Function AsMoney(ByVal dInput As Decimal?) As String
        If dInput Is Nothing Then Return "null"
        Return String.Format("{0:C}", dInput)
    End Function

    <Extension>
    Function line_value(itm As iOrderItem) As Decimal
        Return itm.unit_price * itm.qty_purchased
    End Function

End Module
