Imports System.ComponentModel.DataAnnotations

Public Class clsLayaway
    Inherits clsPreSaleBase
    Implements IValidatableObject

    <Required>
    Property TillNumber As Integer
    Property SourceCodeID As Integer?
    Property MailOrderValues As clsPreSaleMOBase

End Class

'Public Class clsLayawayMailOrderValues
'    Inherits clsPreSaleMOBase
'End Class

Public Class clsPreSaleItemBase
    Inherits clsSalesItem

    'Property Description As String

End Class

Public Class clsPreSaleBase
    Implements IValidatableObject

    Property ID As Integer?

    <StringLength(3, ErrorMessage:="The StoreID must be 3 digits.", MinimumLength:=3)>
    <Required>
    Property StoreID As String

    ''' <summary>
    ''' The date the layaway was created
    ''' </summary>
    ''' <returns></returns>
    Property DateStored As DateTime

    ''' <summary>
    ''' The ID of the sales clerk (or operator) that performed the layaway
    ''' </summary>
    ''' <returns></returns>
    Property OperatorID As String = "SYSTEM"

    <Required>
    Property Products As IEnumerable(Of clsPreSaleItemBase)

    Function ItemsValue() As Decimal
        Return Products.Sum(Function(x) x.LinePrice)
    End Function

    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim results As New List(Of ValidationResult)


        Return results

    End Function



    ''' <summary>
    ''' The Customer ID selected against the sale.
    ''' </summary>
    ''' <returns></returns>
    Property CustomerID As String

End Class

Public Class clsPreSaleMOBase
    Property Notes As String
    Property DeliveryNotes As String
    Property DeliveryAddressRef As String
    Property ShippingRateID As Integer
    Property ShippingValue As Decimal
    Property OrderStatus As Integer
    Property RequestedDeliveryDate As Date
    <StringLength(3, ErrorMessage:="The ClickAndCollectShop length must be 3 characters.", MinimumLength:=3)>
    Property ClickAndCollectShop As String
End Class