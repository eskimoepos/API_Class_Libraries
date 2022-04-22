Imports System.ComponentModel.DataAnnotations

Public Class clsStockAdjustmentInfo
    Inherits EskimoBaseClass

    Enum AdjustmentTypeEnum
        SetToValueSpecified = 1
        AdjustByValueSpecified = 2
    End Enum

    ''' <summary>
    ''' The PLU or SKU code to adjust the stock for
    ''' </summary>
    ''' <returns></returns>
    <StringLength(35)>
    <Required>
    Property SKU_Code As String

    ''' <summary>
    ''' Eskimo has 3 stock locations; 1, 2 and 3. Pass the Stock Location that would like to adjust the stock for.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <Range(1, 3, ErrorMessage:="Vaid stock locations are between 1 and 3")>
    Property StockLocation As Integer

    ''' <summary>
    ''' We can either set the stock level to a particular value, or we can adjust the stock level by an amount; this controls which. The latter is the default if omitted.
    ''' </summary>
    ''' <returns></returns>
    <EnumDataType(GetType(AdjustmentTypeEnum))>
    Property AdjustmentType As AdjustmentTypeEnum = AdjustmentTypeEnum.AdjustByValueSpecified

    ''' <summary>
    ''' The stock level adjustment value, or new stock level, depending on the Adjustment Type
    ''' </summary>
    ''' <returns></returns>
    Property Amount As Integer

    ''' <summary>
    ''' Optional. Useful when looking at the audit trail for a SKU - to find out why the stock level changed on a certain date.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(350)>
    Property AdjustmentReason As String

    ''' <summary>
    ''' This is your own identifier for this adjustment so that when you receive the results, (with the new stock level) you can identify which one matches to your request. Bear in mind that it is possible to pass the same SKU multiple times in the request for Adjustment Type 2.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Property Identifier As String

    ''' <summary>
    ''' Optional. Shop Code. See api/Shops/All  If omitted, the default store number of the database the API is connected to will be adjusted.
    ''' </summary>
    ''' <returns></returns>
    <StringLength(3, ErrorMessage:="The code must be 3 digits.", MinimumLength:=3)>
    Property StoreNumber As String

End Class

Public Class clsStockAdjustmentResult

    Property StoreNumber As String
    Property Identifier As String
    Property StockLevel1 As Integer
    Property StockLevel2 As Integer
    Property StockLevel3 As Integer

End Class

Public Class clsStockAdjustmentBase

    ''' <summary>
    ''' If true, a response will be returned containing the current stock levels. If False, null will be returned, but a Status Code of 200 will indicate success.
    ''' </summary>
    ''' <returns></returns>
    Property ReturnStockLevels As Boolean = True

    ''' <summary>
    ''' Optional. Assigns the stock adjustment to a particular member of staff. If omitted, a system opertator will be assigned.
    ''' </summary>
    ''' <returns></returns>
    Property OperatorID As String

End Class

Public Class clsStockAdjustment
    Inherits clsStockAdjustmentBase
    <Required>
    Property Adjustment As clsStockAdjustmentInfo
End Class

Public Class clsStockAdjustments
    Inherits clsStockAdjustmentBase
    <Required>
    Property Adjustments As List(Of clsStockAdjustmentInfo)
End Class