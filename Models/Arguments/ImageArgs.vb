Imports System.ComponentModel.DataAnnotations

Public Class ImageArgsUpdate
    Inherits ImageArgs

    <Required>
    Property ImageID As Integer

End Class

Public Class ImageArgs
    Implements iControllerArguments, IValidatableObject

    ''' <summary>
    ''' The actual image data
    ''' </summary>
    ''' <returns></returns>
    <Required>
    Property Base64String As String

    ''' <summary>
    ''' The file name for the image. This is unique in the Eskimo system and an error will be thrown if you try to insert one that already exists.
    ''' </summary>
    ''' <returns></returns>
    <Required>
    <StringLength(100)>
    Property FileName As String

    ''' <summary>
    ''' Alternate Text for an image as used here: http://www.w3schools.com/tags/att_img_alt.asp
    ''' </summary>
    ''' <returns></returns>
    <StringLength(400)>
    Property AlternateTag As String

    Private _img As Drawing.Image
    Function Img() As Drawing.Image
        Return _img
    End Function
    Sub SetImage(i As Drawing.Image)
        _img = i
    End Sub

    Function ImgBytes() As Byte()
        Dim b() As Byte
        Using ms As New IO.MemoryStream
            _img.Save(ms, Drawing.Imaging.ImageFormat.Jpeg)
            b = ms.ToArray
        End Using
        Return b
    End Function

    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim lst As New List(Of ValidationResult)
        If Not Me.FileName.ToUpper.EndsWith(".JPG") AndAlso Not Me.FileName.ToUpper.EndsWith(".JPEG") Then
            lst.Add(New ValidationResult("A jpeg filename must be supplied"))
        End If
        Return lst
    End Function
End Class
