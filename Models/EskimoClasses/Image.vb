Imports System.ComponentModel.DataAnnotations

''' <summary>
''' The Image Class. This provides information about the JPG offered.
''' </summary>
Public Class clsImage
    Inherits EskimoBaseClass

    ''' <summary>
    ''' The numeric ID of the Image as generated from Eskimo
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property EskimoImageID As Integer

    ''' <summary>
    ''' The ID of the image as known by the cart
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property WebImageID As String

    ''' <summary>
    ''' The name of the file when it was imported into Eskimo
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property FileName As String

    ''' <summary>
    ''' The width of the image in pixels
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property Width As Integer

    ''' <summary>
    ''' The height of the image in pixels
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property Height As Integer

    ''' <summary>
    ''' The date that the image was added in Eskimo
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Created As Date

    ''' <summary>
    ''' The date that the image was replaced or amended in Eskimo. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LastModified As Date

    ''' <summary>
    ''' The size of the image in Bytes
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    Property FileSize As Long

    ''' <summary>
    ''' Alternate Text for an image as used here: http://www.w3schools.com/tags/att_img_alt.asp
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property AlternateText As String

End Class
