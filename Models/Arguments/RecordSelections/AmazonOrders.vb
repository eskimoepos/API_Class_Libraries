Imports System.ComponentModel.DataAnnotations

Public Class AmazonOrders

    Enum AmazonFulfilmentEnum
        FulfilledByAmazon = 1
        FulfilledByMerchant = 2
    End Enum

    Enum AmazonConditionEnum
        [New] = 1
        UsedLikeNew = 2
        UsedVeryGood = 3
        UsedGood = 4
        UsedAcceptable = 5
        CollectibleLikeNew = 6
        CollectibleVeryGood = 7
        CollectibleGood = 8
        CollectibleAcceptable = 9
        Refurbished = 10
        Club = 11
    End Enum

    Enum AmazonStyledStatusEnum
        parent = 1
        child = 2
        neither = 3
    End Enum

    Enum AmazonCodeTypeEnum
        ISBN = 1
        UPC = 2
        EAN = 3
        ASIN = 4
        GTIN = 5
    End Enum

    <Required>
    Property CreatedAfter As Date

    '<EnumDataType(GetType(AmazonFulfilmentEnum))>
    '<Required>
    'Property FulfillmentChannel As AmazonFulfilmentEnum = AmazonFulfilmentEnum.FulfilledByMerchant

End Class
