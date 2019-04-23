Imports System.ComponentModel.DataAnnotations

Public Class ImageID
    <StringLength(200)>
    Property Eskimo_Image_ID As String
    <StringLength(200)>
    Property Web_Image_ID As String

    ''' <summary>
    ''' Setting this value to true will mark the image in Eskimo as having been received. Subsequent calls to GET api/Images/All will then exclude this image.
    ''' </summary>
    ''' <returns></returns>
    Property MarkAsReceived As Boolean

End Class

