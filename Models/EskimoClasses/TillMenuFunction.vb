Imports System.ComponentModel.DataAnnotations

Public Class clsTillFunctionButton
    Inherits EskimoBaseClass
    Enum FunctionActionEnum
        Customer = 1
        PrintReceipt = 2
        Cancel = 3
        SearchProduct = 4
        Refund = 5
        SalesCode = 6
        [Operator] = 7
        ReprintCardReceipt = 8
        Layaway = 9
        CreateQuote = 10
    End Enum

    <Required>
    Property ID As Integer

    Property NormalState As clsButtonInfo

    Property HoverState As clsButtonInfo

    Property SelectedState As clsButtonInfoBase

    <Required>
    Property FunctionAction As FunctionActionEnum

    <Required>
    Property Position As Integer

End Class

Public Class clsButtonInfoBase
    Property BackColour As String
    Property TextColour As String

End Class

Public Class clsButtonInfo

    Inherits clsButtonInfoBase

    Sub New()

    End Sub

    Sub New(_Text As String)
        Me.ButtonType = ButtonTypeEnum.Text
        Me.Text = _Text
    End Sub
    Sub New(_ImageID As Integer)
        Me.ButtonType = ButtonTypeEnum.Image
        Me.ImageID = _ImageID
    End Sub

    Sub New(_Text As String, _ImageID As Integer)
        Me.ButtonType = ButtonTypeEnum.TextAndImage
        Me.Text = _Text
        Me.ImageID = _ImageID
    End Sub

    Enum ButtonTypeEnum
        Text = 1
        Image = 2
        TextAndImage = 3
    End Enum

    Property ButtonType As ButtonTypeEnum

    ''' <summary>
    ''' See api/Images/ImageData/{id}
    ''' </summary>
    ''' <returns></returns>
    Property ImageID As Integer?
    Property Text As String

End Class