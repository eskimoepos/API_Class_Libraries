Public Class StockTakingValidateOptions
    Inherits EskimoBaseClass
    Implements iControllerArguments

    ''' <summary>
    ''' Each Stock Taking Device will have it's own unique hardware ID. This is passed when incrementing the stock take count figures. Passing a value here will filter the results to just those of that device.
    ''' </summary>
    ''' <returns></returns>
    Property DeviceID As String

    ''' <summary>
    ''' Optional property which when passed, will filter the results for that area. The area is a field passed to the IncrementCounts action.
    ''' </summary>
    ''' <returns></returns>
    Property Area As String

End Class
