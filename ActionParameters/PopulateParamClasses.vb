Public Module modPopulateParamClasses

    Function PopulateNewCustomerClass() As clsCustomer
        Dim ToReturn As New clsCustomer

        With ToReturn
            .ActiveAccount = True
            .Address = "123 High Street" & vbNewLine & "Edinburgh"
            .CompanyName = "Microsoft"
            .EmailAddress = "bill@microsoft.com"
            .Forename = "William"
            .Mobile = "07740 123123"
            .Notes = "Here are some notes about the customer"
            .PostCode = "EH1 3SS"
            .Surname = "Gates"
            .Telephone = "01234 123456"
            .TitleID = 1
            .CountryCode = "GB"
        End With
        Return ToReturn

    End Function

    Function PopulateSendOrder() As clsTillSaleItems
        Dim ToReturn As New clsTillSaleItems
        Dim Tenders As New List(Of clsTenderEntry)
        Dim Items As New List(Of clsTillSaleItem)
        Dim Options As New List(Of clsSaleItemBase)

        Tenders.Add(New clsTenderEntry() With {.TenderID = 1,
                                                        .Amount = 3.5
                                                        })

        Tenders.Add(New clsTenderEntry() With {.TenderID = 2,
                                                        .Amount = 1560.55
                                                        })

        Options.Add(New clsTillSaleItem() With {.PLU = "00000005",
                                                .Qty = 1,
                                                .UnitPrice = 0.5,
                                                .FreeText = "cooking option"})

        Items.Add(New clsTillSaleItem() With {.PLU = "00000001",
                                          .Qty = 5,
                                          .UnitPrice = 5.5,
                                          .ProductOptions = Options})

        Items.Add(New clsTillSaleItem() With {.PLU = "00000002",
                                          .Qty = 1,
                                          .UnitPrice = 12.99,
                                          .FreeText = "Treat as main meal"})

        With ToReturn
            .Tenders = Tenders.AsEnumerable
            .Items = Items.AsEnumerable
            .ActionDate = Now
            .Hospitality = True
        End With
        Return ToReturn

    End Function

    Function PopulateOrderSearch() As GetOrdersArguments
        Dim ToReturn As New GetOrdersArguments

        With ToReturn
            .FromDate = New Date(Now.Year, Now.Month, 1)
            .ToDate = Now
            .IncludeProductDetails = True
            .IncludeCustomerDetails = True
            .OrderType = clsOrder.OrderTypeEnum.WebOrder
        End With

        Return ToReturn

    End Function

    Function PopulateOrderClass() As clsOrder
        Dim ToReturn As New clsOrder

        With ToReturn
            .order_id = 12345
            .amount_paid = 100
            .CustomerReference = "Presents for Debbie"
            .InvoiceAddress = New clsOrderAddressInfo With {
                                                                .AddressLine1 = "123 High Street",
                                                                .CountryCode = "GB",
                                                                .FAO = "Bill Smith",
                                                                .PostalTown = "Birmingham",
                                                                .County = "West Midlands",
                                                                .PostCode = "BR1 1TT"
                                                            }
            .DeliveryAddress = New clsOrderAddressInfo With {
                                                                .AddressLine1 = "Flat 1",
                                                                .AddressLine2 = "Tower of Flats",
                                                                .AddressLine3 = "888 Main Street",
                                                                .CountryCode = "GB",
                                                                .FAO = "Bill Smith",
                                                                .PostalTown = "Poole",
                                                                .County = "Dorset",
                                                                .PostCode = "BH1 1RR"
                                                            }
            .DeliveryNotes = "Please leave package in porch if no reply."
            .eskimo_customer_id = "001-000018"
            .invoice_amount = 100
            .order_date = Now
            .OrderedItems.Add(New clsOrderItem With {.sku_code = "00000001",
                                                     .unit_price = 22.5,
                                                     .qty_purchased = 4,
                                                     .line_discount_amount = 10,
                                                     .item_note = "Katie Smith"
                                                    })
            .OrderedItems.Add(New clsOrderItem With {.sku_code = "00000002",
                                                     .unit_price = 10,
                                                     .qty_purchased = 1,
                                                     .line_discount_amount = 0
                                                    })
            .ShippingRateID = 1
        End With

        Return ToReturn

    End Function

End Module
