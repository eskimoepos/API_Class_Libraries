Public Class CountedProducts
    Inherits clsCountedProducts

    Sub New()
        MyBase.New

        Me.Counts.Add(New clsCountedProduct() With {.AdditionalInfo = "Device Name: Ryan's",
                                            .PLU = "00000005",
                                            .CountAmount = 5,
                                            .Location = 1,
                                            .OperatorID = "1",
                                            .ShelfLocation = "CC12",
                                            .DeviceID = "ABC123",
                                            .DateScanned = Now,
                                            .Area = "Counter"})

        Me.Counts.Add(New clsCountedProduct() With {.AdditionalInfo = "Device Name: Ryan's",
                                            .PLU = "00000006",
                                            .CountAmount = 15,
                                            .Location = 1,
                                            .OperatorID = "1",
                                            .ShelfLocation = "AB11",
                                            .DeviceID = "ABC123",
                                            .DateScanned = Now,
                                            .Area = "Counter"})

        Me.Counts.Add(New clsCountedProduct() With {.AdditionalInfo = "Device Name: Bob's",
                                            .PLU = "00000005",
                                            .CountAmount = 50,
                                            .Location = 2,
                                            .OperatorID = "1",
                                            .ShelfLocation = "ED01",
                                            .DeviceID = "XYZ321",
                                            .DateScanned = Now,
                                            .Area = ""})

    End Sub
End Class
