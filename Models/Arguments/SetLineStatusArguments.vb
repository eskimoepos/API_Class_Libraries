Imports System.ComponentModel.DataAnnotations
Imports EskimoClassLibraries.clsOrderItemExt

Public Class SetLineStatusArguments
    Implements iControllerArguments

    <Required>
    Property OrderId As Integer
    <Required>
    Property Lines As List(Of LineStatusSub)

End Class

Public Class LineStatusSub

    ''' <summary>
    ''' Pass OrderedItems.id from api/Orders/WebsiteOrder/{ID}
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property LineId As String

    <Required>
    <EnumDataType(GetType(OrderStatusEnum))>
    Property NewStatus As OrderStatusEnum

End Class