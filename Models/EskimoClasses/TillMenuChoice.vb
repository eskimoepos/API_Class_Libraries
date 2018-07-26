Public Class clsTillMenuChoice
    Inherits EskimoBaseClass

    ''' <summary>
    ''' The question to be asked to the operator, i.e. How would they like their steak done?
    ''' </summary>
    ''' <returns></returns>
    Property Prompt As String

    ''' <summary>
    ''' The quantity of items to be applied after selection.
    ''' </summary>
    ''' <returns></returns>
    Property Quantity As Integer

    ''' <summary>
    ''' The minimum number of items that must be chosen. 
    ''' </summary>
    ''' <returns></returns>
    Property MinRequired As Integer = 0
    ''' <summary>
    ''' The maximum number of items that must be chosen.
    ''' </summary>
    ''' <returns></returns>
    Property MaxRequired As Integer = 1

    ''' <summary>
    ''' A list of the possible choices. i.e. Rare, Medium, Well Done etc.   Some options will incur a cost, others will be free.
    ''' </summary>
    ''' <returns></returns>
    Property Choices As List(Of clsTillMenuItem)

End Class
