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
End Class
