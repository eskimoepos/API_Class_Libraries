Imports System.ComponentModel.DataAnnotations

Public Class clsWebTillLog

    <Required>
    Property Text As String

    <Required>
    <EnumDataType(GetType(LogTypeEnum))>
    Property LogType As LogTypeEnum

    Property MachineToken As String
    Enum LogTypeEnum
        UserActivity = 1
        Hardware = 2
    End Enum
End Class
