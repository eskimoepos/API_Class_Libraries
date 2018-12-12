Public Class clsMeasureUnit

    Inherits EskimoBaseClass

    Enum MeasureTypeEnum
        Distance = 1
        Weight = 2
        Volume = 3
    End Enum

    ''' <summary>
    ''' The Eskimo Primary Key of the Measure Unit
    ''' </summary>
    ''' <returns></returns>
    Property ID As Integer

    ''' <summary>
    ''' The symbold to display after the value; i.e. mm, lb, kg
    ''' </summary>
    ''' <returns></returns>
    Property Symbol As String

    ''' <summary>
    ''' A description of the measure unit; i.e. Kilograms
    ''' </summary>
    ''' <returns></returns>
    Property Description As String

    ''' <summary>
    ''' If this unit is not a base measurement, the BaseModifier and LinkedBaseMeasureID fields will have a value, otherwise they will be null.
    ''' </summary>
    ''' <returns></returns>
    Property IsBaseUnit As Boolean

    ''' <summary>
    ''' The number of the Base Unit that equals 1 of this unit.
    ''' </summary>
    ''' <returns></returns>
    Property BaseModifier As Decimal?

    ''' <summary>
    ''' The type of measurment i.e. Weight, Distance, Volume
    ''' </summary>
    ''' <returns></returns>
    Property Type As MeasureTypeEnum

    ''' <summary>
    ''' If this meausure type is not a base unit, then this property contains the ID of the measure unit that is.
    ''' </summary>
    ''' <returns></returns>
    Property LinkedBaseMeasureID As Integer?

End Class


Public Class clsMeasureUnits
    Property Units As New List(Of clsMeasureUnit)

    ''' <summary>
    ''' Example function to show how to convert from one unit to another
    ''' </summary>
    ''' <param name="value">The amound to be converted</param>
    ''' <param name="idIn">The Eskimo ID of the measure unit assigned to the product</param>
    ''' <param name="idOut">The Eskimo ID of the meaure unit desired</param>
    ''' <returns></returns>
    Function ConvertTo(value As Decimal, idIn As Integer, idOut As Integer) As Decimal
        Dim inMeasure As clsMeasureUnit
        Dim outMeasure As clsMeasureUnit
        Dim decMod1 As Decimal = 1
        Dim decMod2 As Decimal = 1

        inMeasure = Me.Units.FirstOrDefault(Function(x) x.ID = idIn)
        If idIn = idOut Then
            outMeasure = inMeasure
        Else
            outMeasure = Me.Units.FirstOrDefault(Function(x) x.ID = idOut)
        End If

        If inMeasure Is Nothing Then Throw New Exception($"Input measure ID {idIn} not found")
        If outMeasure Is Nothing Then Throw New Exception($"Output measure ID {idOut} not found")
        If inMeasure.Type <> outMeasure.Type Then Throw New Exception($"Unable to convert different measure types. Input measure type is {inMeasure.Type} and output is {outMeasure.Type}")

        If Not inMeasure.IsBaseUnit Then decMod1 = inMeasure.BaseModifier
        If Not outMeasure.IsBaseUnit Then decMod2 = outMeasure.BaseModifier

        Return (value * decMod1) / decMod2

    End Function

End Class