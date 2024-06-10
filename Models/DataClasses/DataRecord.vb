Imports System.Data.SqlClient

Public Class DataRecord
    Implements IDataRecord

    Private booIsDataRow As Boolean
    ReadOnly Property rdr As SqlDataReader
    ReadOnly Property row As DataRow

        Private function CollectionType As String
        If booIsDataRow Then
            Return "data reader"
        Else
            Return "data row"
        End If
    End function
    Sub New(_rdr As SqlDataReader)
        rdr = _rdr
    End Sub

    Sub New(_row As DataRow)
        booIsDataRow = True
        row = _row
    End Sub

    Public ReadOnly Property FieldCount As Integer Implements IDataRecord.FieldCount
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Default Public ReadOnly Property Item(name As String) As Object Implements IDataRecord.Item

        Get
            Try
                If booIsDataRow Then
                    Return row.Item(name)
                Else
                    Return rdr.Item(name)
                End If

            Catch badfield As ArgumentOutOfRangeException
                Throw New Exception($"field name {name} not found in {Me.CollectionType}")
            Catch ex As Exception

                If ex.Message = name Then
                    Throw New Exception($"Field name {name} not found in {Me.CollectionType}")
                End If

                Throw
            End Try
        End Get
    End Property

    Default Public ReadOnly Property Item(i As Integer) As Object Implements IDataRecord.Item
        Get
            If booIsDataRow Then
                Return row.Item(i)
            Else
                Return rdr.Item(i)
            End If
        End Get
    End Property

    Public Function ColumnExists(strName As String) As Boolean
        If booIsDataRow Then
            Return row.Table.Columns.Contains(strName)
        Else
            Using tbl As DataTable = rdr.GetSchemaTable()
                Return tbl.Columns.Contains(strName)
            End Using
        End If
    End Function

    Public Function GetBoolean(i As Integer) As Boolean Implements IDataRecord.GetBoolean
        Throw New NotImplementedException()
    End Function

    Public Function GetByte(i As Integer) As Byte Implements IDataRecord.GetByte
        Throw New NotImplementedException()
    End Function

    Public Function GetBytes(i As Integer, fieldOffset As Long, buffer() As Byte, bufferoffset As Integer, length As Integer) As Long Implements IDataRecord.GetBytes
        Throw New NotImplementedException()
    End Function

    Public Function GetChar(i As Integer) As Char Implements IDataRecord.GetChar
        Throw New NotImplementedException()
    End Function

    Public Function GetChars(i As Integer, fieldoffset As Long, buffer() As Char, bufferoffset As Integer, length As Integer) As Long Implements IDataRecord.GetChars
        Throw New NotImplementedException()
    End Function

    Public Function GetData(i As Integer) As IDataReader Implements IDataRecord.GetData
        Throw New NotImplementedException()
    End Function

    Public Function GetDataTypeName(i As Integer) As String Implements IDataRecord.GetDataTypeName
        Throw New NotImplementedException()
    End Function

    Public Function GetDateTime(i As Integer) As Date Implements IDataRecord.GetDateTime
        Throw New NotImplementedException()
    End Function

    Public Function GetDecimal(i As Integer) As Decimal Implements IDataRecord.GetDecimal
        Throw New NotImplementedException()
    End Function

    Public Function GetDouble(i As Integer) As Double Implements IDataRecord.GetDouble
        Throw New NotImplementedException()
    End Function

    Public Function GetFieldType(i As Integer) As Type Implements IDataRecord.GetFieldType
        Throw New NotImplementedException()
    End Function

    Public Function GetFloat(i As Integer) As Single Implements IDataRecord.GetFloat
        Throw New NotImplementedException()
    End Function

    Public Function GetGuid(i As Integer) As Guid Implements IDataRecord.GetGuid
        Throw New NotImplementedException()
    End Function

    Public Function GetInt16(i As Integer) As Short Implements IDataRecord.GetInt16
        Throw New NotImplementedException()
    End Function

    Public Function GetInt32(i As Integer) As Integer Implements IDataRecord.GetInt32
        Throw New NotImplementedException()
    End Function

    Public Function GetInt64(i As Integer) As Long Implements IDataRecord.GetInt64
        Throw New NotImplementedException()
    End Function

    Public Function GetName(i As Integer) As String Implements IDataRecord.GetName
        Throw New NotImplementedException()
    End Function

    Public Function GetOrdinal(name As String) As Integer Implements IDataRecord.GetOrdinal
        Throw New NotImplementedException()
    End Function

    Public Function GetString(i As Integer) As String Implements IDataRecord.GetString
        Throw New NotImplementedException()
    End Function

    Public Function GetValue(i As Integer) As Object Implements IDataRecord.GetValue
        Throw New NotImplementedException()
    End Function

    Public Function GetValues(values() As Object) As Integer Implements IDataRecord.GetValues
        Throw New NotImplementedException()
    End Function

    Public Function IsDBNull(i As Integer) As Boolean Implements IDataRecord.IsDBNull
        Throw New NotImplementedException()
    End Function
End Class
