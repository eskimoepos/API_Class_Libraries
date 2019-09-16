Imports System.ComponentModel.DataAnnotations

Public Class clsWebTillActionBase
    Enum ActionTypeEnum
        DownloadAll = 1
        DownloadCustomers = 2
        DownloadOperators = 3
        DownloadSourceCodes = 4
        DownloadTenderTypes = 5
        DownloadTaxCodes = 6
        DownloadDeliveryMethods = 7
        DownloadSalesChannels = 8
        DownloadPriceBreaks = 9
        DownloadProducts = 10
        DownloadTillMenu = 11
        DownloadDeviceSettings = 12
        DownloadCountries = 13
        RetryFailedSales = 14
        DownloadShops = 15
        DownloadPriceLists = 16
        UpdateBetaApp = 17
        UpdateLiveApp = 18
    End Enum

    Enum ActionStatusEnum
        Pending = 1
        Completed = 2
        Failed = 3
    End Enum


    <Required>
    Property Id As String



End Class

Public Class clsWebTillAction
    Inherits clsWebTillActionBase

    <EnumDataType(GetType(ActionTypeEnum))>
    <Required>
    Property ActionType As ActionTypeEnum
    Property DateLastUpdated As Date
    Property DateCreated As Date

    '''' <summary>
    '''' Nullable. Don't attempt the action until this date/time
    '''' </summary>
    '''' <returns></returns>
    'Property EarliestActionTime As Date?
End Class

Public Class clsWebTillActionResult

    Inherits clsWebTillActionBase
    Implements IValidatableObject

    <Required>
    <EnumDataType(GetType(ActionStatusEnum))>
    Property ActionStatus As ActionStatusEnum

    Property ErrorMessage As String

    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim lst As New List(Of ValidationResult)

        If Not String.IsNullOrEmpty(ErrorMessage) AndAlso Not ActionStatus = ActionStatusEnum.Failed Then
            lst.Add(New ValidationResult("Only need to pass ErrorMessage if the result was 'Failed'"))
        End If

        Select Case Me.ActionStatus
            Case ActionStatusEnum.Completed, ActionStatusEnum.Failed
            Case Else
                lst.Add(New ValidationResult("Invalid status"))
        End Select

        Return lst
    End Function
End Class