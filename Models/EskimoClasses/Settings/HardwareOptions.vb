Public Class clsHardwareOptions

    ''' <summary>
    ''' Determines if the on-screen keyboard will show automatically when the user clicks into an input textbox 
    ''' </summary>
    ''' <returns></returns>
    Property AutoPopupKeyboard As Boolean

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
