Imports System.ComponentModel.DataAnnotations

''' <summary>
''' A class to specify filtering options for the data that is returned
''' </summary>
''' <remarks></remarks>
Public Class RecordSelectionWithDate
    Inherits EskimoClassLibraries.RecordSelection

    ''' <summary>
    ''' Optional property that enables you to only receive products that have been added or modified in the Eskimo system since this timestamp. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property TimeStampFrom As DateTime = #1/1/2000#

End Class