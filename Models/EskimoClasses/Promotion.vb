Public Class clsPromotion

    Inherits EskimoBaseClass

    ''' <summary>
    ''' The Eskimo PK for the Promotion
    ''' </summary>
    ''' <returns></returns>
    Property ID As Integer

    ''' <summary>
    ''' A name for the promotion, provided by the retailer
    ''' </summary>
    ''' <returns></returns>
    Property Name As String

    ''' <summary>
    ''' Whether the promotion is enabled/disabled. If this value is True, but the date is not within the Active date range, then is should be considered Inactive.
    ''' </summary>
    ''' <returns></returns>
    Property Active As Boolean

    ''' <summary>
    ''' The date/time that the promotion should be active from
    ''' </summary>
    ''' <returns></returns>
    Property ActiveFrom As Date?

    ''' <summary>
    ''' The date/time that the promotion should be active until
    ''' </summary>
    ''' <returns></returns>
    Property ActiveTo As Date?

    ''' <summary>
    ''' This promotion can only be used once per customer.
    ''' </summary>
    ''' <returns></returns>
    Property SingleUse As Boolean

    ''' <summary>
    ''' This promotion cannot be used in conjunction with any other promotions.
    ''' </summary>
    ''' <returns></returns>
    Property SoloUse As Boolean

    ''' <summary>
    ''' A list of conditions or rules that must be met before the bonuses are applied.
    ''' </summary>
    ''' <returns></returns>
    Property Conditions As New List(Of clsPromotionCondition)

    ''' <summary>
    ''' Defines the products that are pertinent to this promotion. The criteria in each collection must be present in order to fulfil the condition.
    ''' </summary>
    ''' <returns></returns>
    Property ProductSelection As New List(Of clsPromotionProductSelections)

    ''' <summary>
    ''' A list of the benefits to apply to the sale, should the conditions be met
    ''' </summary>
    ''' <returns></returns>
    Property Bonuses As New List(Of clsPromotionBonus)

End Class
