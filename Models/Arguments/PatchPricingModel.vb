Imports System.ComponentModel.DataAnnotations

Public Class PricePatchingCollection
    Implements IValidatableObject
    Public Property Entries As List(Of PatchPricingModel)


    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim results As New List(Of ValidationResult)

        ' Get all SKUs from PatchPricingModel instances in the collection
        Dim allSKUs = Me.Entries.Select(Function(model) model.SKU)

        ' Check for duplicate SKUs within the entire collection
        Dim duplicateSKUs = allSKUs.GroupBy(Function(sku) sku).Where(Function(g) g.Count() > 1).Select(Function(g) g.Key).ToList()

        If duplicateSKUs.Any() Then
            results.Add(New ValidationResult($"Duplicate SKUs found: {String.Join(", ", duplicateSKUs)}.", {"PricesList"}))
        End If

        Return results
    End Function


End Class

Public Class PatchPricingModel

    <Required>
    Property SKU As String
    Property BuyCost As Decimal?
    Property AdditionalCost As Decimal?
    Property Prices As New List(Of PricePatch)

End Class

Public Class PricePatch
    <Required>
    <Range(1, 10)>
    Property PriceLevel As Integer
    <Required>
    Property SellPrice As Decimal
End Class
