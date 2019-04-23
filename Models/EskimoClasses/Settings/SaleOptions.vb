Public Class clsSaleOptions
    Property ShowPLUonBasket As Boolean
    Property ConsolidateItems As Boolean
    ''' <summary>
    ''' See api/MeasureUnits/All
    ''' </summary>
    ''' <returns></returns>
    Property WeightMeasureUnitID As Integer?

    ''' <summary>
    ''' When items are scanned into the basket, this is the default channel they will use. See api/Sales/Channels
    ''' </summary>
    ''' <returns></returns>
    Property DefaultChannelID As Integer
    Property SellAtBestPrice As Boolean
    Property BasketShowsSalesChannelType As Boolean
    Property DefaultShippingRate As Integer?
    ''' <summary>
    ''' Methods by which a sale can come into a business. These may include Email, Phone, Shop Counter etc.
    ''' </summary>
    ''' <returns></returns>
    Property Sources As IEnumerable(Of clsSaleSource)

    ''' <summary>
    ''' If false, newly added products get added to the bottom of the basket.
    ''' </summary>
    ''' <returns></returns>
    Property AddNewProductsToBasketTop As Boolean
    Property HideDiscountButton As Boolean

    Property MailOrderPrefix As String
    Property ShowPrinterChoicePopup As Boolean
End Class

Public Class clsSaleSource
    Property ID As Integer
    Property Description As String
    Property Active As Boolean
End Class