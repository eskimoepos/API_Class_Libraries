Imports System.ComponentModel.DataAnnotations

Public Class clsReceiptMargin
    Inherits EskimoBaseClass

    Enum EntryTypeEnum
        Image = 1
        TextLine = 2
        BoldTextLine = 3
    End Enum

    <EnumDataType(GetType(EntryTypeEnum))>
    <Required>
    Property Type As EntryTypeEnum

    Property Text As String

    Property Logo As Drawing.Image

End Class
