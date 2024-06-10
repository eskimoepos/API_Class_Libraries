Public Enum AdditionalDescriptionTypeEnum
    StyleRef = 1
    PLU = 2
    Group = 3
    Department = 4
End Enum

Public Class clsAdditionalDescription
    ''' <summary>
    ''' The ID of the Style, PLU, Department in question.
    ''' </summary>
    ''' <returns></returns>
    Property Destination As String
    ''' <summary>
    ''' The destination type
    ''' </summary>
    ''' <returns></returns>
    Property Type As AdditionalDescriptionTypeEnum
    ''' <summary>
    ''' A title for the additional description.
    ''' </summary>
    ''' <returns></returns>
    Property Title As String
    ''' <summary>
    ''' The html content of the description
    ''' </summary>
    ''' <returns></returns>
    Property Content As String
    ''' <summary>
    ''' The date/time stampt of the last edit made
    ''' </summary>
    ''' <returns></returns>
    Property LastModified As DateTime
End Class
