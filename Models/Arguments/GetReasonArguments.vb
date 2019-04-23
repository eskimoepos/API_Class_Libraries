Imports System.ComponentModel.DataAnnotations
Imports EskimoClassLibraries.clsReason

Public Class GetReasonArguments
    Inherits EskimoBaseClass

    <Required>
    Property Active As FilterEnum = FilterEnum.Enforce

    Property UseageAspect As ReasonAspectEnum?
    Property StockAction As ReasonActionEnum?

End Class
