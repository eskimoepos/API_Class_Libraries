Imports System.ComponentModel.DataAnnotations

Public Class clsPromotionBonus

    Inherits EskimoBaseClass

    ''' <summary>
    ''' The Bonus ID
    ''' </summary>
    ''' <returns></returns>
    Property ID As Integer

    ''' <summary>
    ''' A short description of what the bonus does. Specified by the operator who setup the promotion.
    ''' </summary>
    ''' <returns></returns>
    Property Description As String

    ''' <summary>
    ''' The order in which the bonuses should be applied
    ''' </summary>
    ''' <returns></returns>
    Property OrderBy As Integer

    ''' <summary>
    ''' Determines if the bonus should be applied again and again for each matching condition found. For instance BOGOF where 10 of that product are in the basket.
    ''' </summary>
    ''' <returns></returns>
    Property Recursive As Boolean

    ''' <summary>
    ''' The type of bonus to be applied.
    ''' </summary>
    ''' <returns></returns>
    <EnumDataType(GetType(BonusTypeEnum))>
    Property BonusType As BonusTypeEnum

    ''' <summary>
    ''' The main value used in the bonus.
    ''' </summary>
    ''' <returns></returns>
    Property XValue As Decimal?

    ''' <summary>
    ''' A secondary value. Used mainly to specify the number of cheapest products applicable.
    ''' </summary>
    ''' <returns></returns>
    Property YValue As Decimal?

    ''' <summary>
    ''' Specifies the details about the free (or reduced) products that should be added to the sale when the bonus is applied. Applicable only when the Bonus Type is 50
    ''' </summary>
    ''' <returns></returns>
    Property GiftInfo As clsPromotionBonusGiftInfo

    ''' <summary>
    ''' Read-Only. A simple human-friendly description of what the bonus does.
    ''' </summary>
    ''' <returns></returns>
    ReadOnly Property FriendlyOutline() As String
        Get
            Select Case Me.BonusType
                Case BonusTypeEnum.PercentageOffOrderValue
                    Return $"{Me.XValue}% off order value (exc shipping)"
                Case BonusTypeEnum.MoneyOffOrderValue
                    Return $"{Me.XValue.AsMoney} off order value (exc shipping)"
                Case BonusTypeEnum.PercentageOffShipping
                    Return $"{Me.XValue}% off shipping"
                Case BonusTypeEnum.MoneyOffShipping
                    Return $"{Me.XValue.AsMoney} off shipping"
                Case BonusTypeEnum.FreeGiftWithPurchase
                    Return $"{Me.GiftInfo.Qty} x {Me.GiftInfo.PLU} added to basket at {Me.GiftInfo.Price.AsMoney} each"
                Case BonusTypeEnum.MoneyOffSelectProducts
                    Return $"{Me.XValue.AsMoney} off all products in selection"
                Case BonusTypeEnum.PercentageOffSelectProducts
                    Return $"{Me.XValue}% off all products in selection"
                Case BonusTypeEnum.MoneyOffCheapestInSelection
                    Return $"{Me.XValue.AsMoney} off the cheapest {IIf(Me.YValue = 1, "product", $"{Me.YValue} products")} in selection"
                Case BonusTypeEnum.PercentageOffCheapestInSelection
                    Return $"{Me.XValue}% off the cheapest {IIf(Me.YValue = 1, "product", $"{Me.YValue} products")} in selection"
                Case BonusTypeEnum.AllMatchingProductForCertainValue
                    Return $"Get all products in selection for {Me.XValue.AsMoney}"
            End Select
            Return ""
        End Get

    End Property

    Enum BonusTypeEnum
        ''' <summary>
        ''' X% off order value (excluding shipping)
        ''' </summary>
        PercentageOffOrderValue = 10

        ''' <summary>
        ''' £x off order value (excluding shipping)
        ''' </summary>
        MoneyOffOrderValue = 20

        ''' <summary>
        ''' X% off shipping cost
        ''' </summary>
        PercentageOffShipping = 30

        ''' <summary>
        ''' £X off shipping cost
        ''' </summary>
        MoneyOffShipping = 40

        ''' <summary>
        ''' Free (or cheaper) gift(s) (products added to the sale automatically). See GiftInfo property
        ''' </summary>
        FreeGiftWithPurchase = 50

        ''' <summary>
        ''' £X off select products
        ''' </summary>
        MoneyOffSelectProducts = 60

        ''' <summary>
        ''' X% off select products
        ''' </summary>
        PercentageOffSelectProducts = 70

        ''' <summary>
        ''' £X off the cheapest Y products in selection
        ''' </summary>
        MoneyOffCheapestInSelection = 80

        ''' <summary>
        ''' X% off the cheapest Y products in selection
        ''' </summary>
        PercentageOffCheapestInSelection = 90

        ''' <summary>
        ''' Get all products in selection for £X
        ''' </summary>
        AllMatchingProductForCertainValue = 100
    End Enum
End Class

Public Class clsPromotionBonusGiftInfo
    ''' <summary>
    ''' The Unit selling price of the product. The could be £0.00 if they are getting the product for free.
    ''' </summary>
    ''' <returns></returns>
    Property Price As Decimal

    ''' <summary>
    ''' The number of that product to add to the basket.
    ''' </summary>
    ''' <returns></returns>
    Property Qty As Integer

    ''' <summary>
    ''' The PLU/SKU code of the product to add to the basket.
    ''' </summary>
    ''' <returns></returns>
    Property PLU As String
End Class