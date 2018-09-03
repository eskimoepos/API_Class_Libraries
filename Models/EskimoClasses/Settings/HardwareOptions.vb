Public Class clsHardwareOptions

    ''' <summary>
    ''' A collection of till hardware models relevant for this particular till.
    ''' </summary>
    ''' <returns></returns>
    Property HardwareModels As IEnumerable(Of clsHardwareModel)

    ''' <summary>
    ''' A collection of till hardware that is connected to this particular till.
    ''' </summary>
    ''' <returns></returns>
    Property Hardware As IEnumerable(Of clsHardwareItem)

End Class
