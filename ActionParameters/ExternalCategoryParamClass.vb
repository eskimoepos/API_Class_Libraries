Public Class ExternalCategoryParamClass
    Inherits clsExternalCategory

    Sub New()
        MyBase.New("83042", clsListing.ListingTypeEnum.eBay, "Vintage Golf Balls", New List(Of clsItemSpecifics))
        Me.CategoryLevel = 1
        Me.ItemSpecifics.Add(New clsItemSpecifics With {.SpecificsName = "Brand",
                                                        .ValueType = clsItemSpecifics.ValueTypeEnum.Text,
                                                        .MaxSelected = 1,
                                                        .MinSelected = 0,
                                                        .SelectionMode = clsItemSpecifics.SelectionModeEnum.FreeText,
                                                        .Values = {"Unbranded", "Acuity", "Ahead", "Bella", "Bettinardi", "Bionic", "Boccieri", "Bonjoc", "Bridgestone", "Brush-t"}})
        Me.ItemSpecifics.Add(New clsItemSpecifics With {.SpecificsName = "MPN",
                                                        .ValueType = clsItemSpecifics.ValueTypeEnum.Text,
                                                        .MaxSelected = 1,
                                                        .MinSelected = 0,
                                                        .SelectionMode = clsItemSpecifics.SelectionModeEnum.FreeText,
                                                        .Values = {"Does Not Apply"}})
        Me.ItemSpecifics.Add(New clsItemSpecifics With {.SpecificsName = "Country/Region of Manufacture",
                                                        .ValueType = clsItemSpecifics.ValueTypeEnum.Text,
                                                        .MaxSelected = 1,
                                                        .MinSelected = 0,
                                                        .SelectionMode = clsItemSpecifics.SelectionModeEnum.SelectionOnly,
                                                        .Values = {"Unknown", "Afghanistan", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla"}})
    End Sub
End Class
