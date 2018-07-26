Imports System.ComponentModel.DataAnnotations

Public Class clsAmazonUploadProductArguments
    Implements iControllerArguments

    <Required>
    Property ProductInfoFeed As FeedRequirement

    <Required>
    Property PricingFeed As FeedRequirement

    <Required>
    Property InventoryFeed As FeedRequirement

    <Required>
    Property RelationshipsFeed As FeedRequirement

    <Required>
    Property ImagesFeed As FeedRequirement

End Class

Public Class FeedRequirement
    <Required>
    Property ProcessFeed As Boolean
    <Required>
    Property OnlyWhereChanged As Boolean
    <Required>
    Property WaitForResult As Boolean
End Class