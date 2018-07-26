DECLARE @Error NVARCHAR(200)

IF	NOT EXISTS(SELECT * FROM dbo.ExternalListings WHERE ListingID = @EskimoListingID)
	BEGIN
		SELECT @Error = N'Listing ID ' + CONVERT(VARCHAR(10),@EskimoListingID) + ' not found.'
		RAISERROR(@Error,16,1)
		RETURN
	END

IF	EXISTS(SELECT * FROM dbo.ExternalListings WHERE ListingID = @EskimoListingID AND ExternalID IS NOT NULL)
	BEGIN
		SELECT @Error = N'Listing ID ' + CONVERT(VARCHAR(10),@EskimoListingID) + ' already marked as listed.'
		RAISERROR(@Error,16,1)
		RETURN
	END	
	
UPDATE		dbo.ExternalListings 
SET			ExternalID = @ExternalListingID, 
			DateListedExternally = @DateListedExternally 
WHERE		ListingID = @EskimoListingID	