Imports System.ComponentModel.DataAnnotations

Public Class clsShippingType

    Inherits EskimoBaseClass
    <Key>
    Property ID As Integer
    Property Active As Boolean
    <StringLength(100)>
    Property Description As String
    Property Rates As New List(Of clsShippingRate)
    <StringLength(50)>
    Property CourierCompany As String

End Class

Public Class clsShippingRate
    Inherits EskimoBaseClass

    <Key>
    Property ID As Integer
    Property BasketWeightFrom As Integer?
    Property BasketWeightTo As Integer?
    Property BasketWeightMeasure As String

    Property BasketValueFrom As Decimal?
    Property BasketValueTo As Decimal?

    Property BasketItemsCountFrom As Integer?
    Property BasketItemsCountTo As Integer?

    Property NetChargeToCustomer As Decimal
    Property GrossChargeToCustomer As Decimal
    Property TaxCode As clsTaxCode
    Property Active As Boolean

End Class