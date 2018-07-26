Public Class CompletedListings
    Inherits PostedListings
    Sub New()
        Dim l As New List(Of PostedListing)

        l.Add(New PostedListing() With {.DateListed = Now, .EskimoListingID = 1, .ExternalListingID = "ABC123"})
        l.Add(New PostedListing() With {.DateListed = Now.AddHours(-16), .EskimoListingID = 2, .ExternalListingID = "DEF689"})
        Me.Listings = l
    End Sub


End Class
