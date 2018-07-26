Public Class clsAmazonFeedResult
    Inherits EskimoBaseClass
    Enum AmazonFeedType
        InventoryFeed = 1
        PricingFeed = 2
        ProductInformationFeed = 3
        ImagesFeed = 4
        RelationshipsFeed = 5
        ShippingOverrides = 6
    End Enum

    Property FeedType As AmazonFeedType
    Property FeedSubmissionId As Long?
    Property Result As String
    Property ErrorMessage As String
End Class
