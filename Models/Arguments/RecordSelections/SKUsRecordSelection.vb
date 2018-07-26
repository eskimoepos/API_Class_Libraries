Public Class SKUsRecordSelection
    Inherits RecordSelectionWithDate

    ''' <summary>
    ''' If this property is turned on, SKUs that have had stock level changes will also be included in the results regardless of whether their actual product information has changed.
    ''' </summary>
    ''' <returns></returns>
    Property IncludeStockAdjustments As Boolean = False

End Class
