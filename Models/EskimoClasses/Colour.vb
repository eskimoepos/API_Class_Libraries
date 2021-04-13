Imports System.ComponentModel.DataAnnotations

Public Class clsColour
    Inherits EskimoBaseClass

    <Required>
    <StringLength(6)>
    Property ID As String

    <Required>
    <StringLength(50)>
    Property Name As String

    Property ColourCode As clsColourCode

End Class


Public Class clsColourCode
    Implements IValidatableObject

    <Range(0, 255)>
    Property Red As Integer?

    <Range(0, 255)>
    Property Green As Integer?

    <Range(0, 255)>
    Property Blue As Integer?

    Property Hex As String

    Sub New()

    End Sub

    Sub New(intVal As Integer)

        Try

            Call PopulateRGB(intVal)
            Me.Hex = RGBtoHex(Me.Red, Me.Green, Me.Blue)

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Function RGBtoHex(_r As Integer, _g As Integer, _b As Integer) As String

        Try

            Dim c As Drawing.Color = Drawing.Color.FromArgb(_r, _g, _b)
            Return Drawing.ColorTranslator.ToHtml(c)

        Catch ex As Exception
            Throw
        End Try

    End Function

    Sub PopulateRGB(strHex As String)

        Try

            Dim c As Drawing.Color = Drawing.ColorTranslator.FromHtml(strHex)

            Me.Red = c.R
            Me.Green = c.G
            Me.Blue = c.B

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Sub PopulateRGB(intInput As Integer)
        Dim b() As Byte

        Try

            b = BitConverter.GetBytes(intInput)

            Me.Red = b(0)
            Me.Green = b(1)
            Me.Blue = b(2)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        Dim lst As New List(Of ValidationResult)
        Dim tmpHex As String
        Dim booRGBsPassed As Boolean = Me.Red IsNot Nothing AndAlso Me.Green IsNot Nothing AndAlso Me.Blue IsNot Nothing

        If Me.Hex <> String.Empty AndAlso booRGBsPassed Then
            tmpHex = RGBtoHex(Me.Red, Me.Green, Me.Blue)
            If Me.Hex <> tmpHex Then
                lst.Add(New ValidationResult($"If passing both RBB and Hex values, they must match. However the hex for {Me.Red},{Me.Green},{Me.Blue} is {tmpHex} not {Me.Hex}"))
            End If
        End If

        If Not booRGBsPassed AndAlso Nz(Me.Hex) = String.Empty Then
            lst.Add(New ValidationResult("Neither RGB or Hex values received. If the colour code is not known, pass null"))
        End If

        If Not booRGBsPassed AndAlso Nz(Me.Hex) <> String.Empty Then
            PopulateRGB(Me.Hex)
        End If

        Return lst

    End Function
End Class