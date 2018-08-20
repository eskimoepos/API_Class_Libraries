Imports System.ComponentModel.DataAnnotations

Public Class clsHardwareItem

    Inherits EskimoBaseClass

    <Required>
    Property ID As Integer

    <Required>
    Property Description As String

    Enum HardwareTypeEnum
        ReceiptPrinter = 1
        CashDrawer = 2
        BarcodePrinter = 3
        EFTPinPad = 4
        KitchenPrinter = 5
    End Enum

    Enum ConnectionTypeEnum
        IPAddress = 1
        OperatingSystemControlled = 2
        OPOS = 3
    End Enum

    Enum EFTAcquirerEnum
        NotApplicable = 0
        EskimoPay = 1
        WorldPay = 2
        Mastercard = 3
        VeriFone = 4
        SagePay = 5
        PaymentSense = 6
    End Enum

    <Required>
    Property ModelID As Integer

    <EnumDataType(GetType(ConnectionTypeEnum))>
    <Required>
    Property ConnectionType As ConnectionTypeEnum

    Property Location As String

    Property UserID As String
    Property Password As String

    <Required>
    Property IsDefault As Boolean

    <EnumDataType(GetType(EFTAcquirerEnum))>
    <Required>
    Property EFTAcquirer As EFTAcquirerEnum

End Class

Public Class clsHardwareModel

    <Required>
    Property ModelID As Integer

    <EnumDataType(GetType(clsHardwareItem.HardwareTypeEnum))>
    <Required>
    Property HardwareType As clsHardwareItem.HardwareTypeEnum

    <Required>
    Property Name As String

    Property Thumbnail As Drawing.Image

End Class