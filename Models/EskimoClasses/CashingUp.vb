Imports System.ComponentModel.DataAnnotations
Imports System.Reflection
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json.Serialization

Public Class clsCashingUpColumn
    Inherits EskimoBaseClass
    Implements ICloneable

    Enum CashingUpColumnDataTypeEnum
        [String] = 0
        [Integer] = 1
        [Currency] = 2
        DateTime = 3
    End Enum

    Property ColumnID As Integer
    Property Name As String
    Property CashDrawerID As Integer?
    Property OrderBy As Integer
    Property Filterable As Boolean = True
    Property Hidden As Boolean
    <Required>
    <EnumDataType(GetType(CashingUpColumnDataTypeEnum))>
    Property DataType As CashingUpColumnDataTypeEnum

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class

'Public Class clsCashingUpSummaryCell
'    Inherits EskimoBaseClass
'    Property ColumnID As Integer
'    Property TillNumber As Integer
'    Property StoreNumber As String
'    Property Value As Decimal?
'End Class

Public Module TransactionColumnConstants
    Public Const SaleNo As String = "Sale No."
    Public Const ReceiptNo As String = "Receipt Number"
    Public Const TransValue As String = "Transaction Value"
    Public Const FilterValue As String = "Filter Value"
    Public Const DateAndTime As String = "Date/Time"
    Public Const OperatorName As String = "Operator"
    Public Const Tenders As String = "Tenders"

    Public Const Reference As String = "Reference"
    Public Const CustomerName As String = "Customer Name"
    Public Const CustomerType As String = "Customer Type"

    'Public Const AuthCode As String = "Auth Code"
    'adjust TryGetMember below
End Module

Public Class clsCashingUpTransaction

    'Inherits Dynamic.DynamicObject

    'Private strFilterName As String
    'Public Property Data As IEnumerable(Of T)

    'Public Overrides Iterator Function GetDynamicMemberNames() As IEnumerable(Of String)
    '    Yield strFilterName

    '    'For Each prop In [GetType]().GetProperties().Where(Function(p) p.Name <> NameOf(Data))
    '    '    Debug.Print(prop.ToString)
    '    'Next

    '    'Dim json As JObject = JObject.FromObject(Me)

    '    For Each prop In [GetType]().GetProperties().Where(Function(p) p.CanRead AndAlso p.GetIndexParameters().Length = 0 AndAlso p.Name <> NameOf(Data))
    '        Yield prop.Name
    '    Next
    'End Function

    'Public Overrides Function TryGetMember(ByVal binder As Dynamic.GetMemberBinder, <Runtime.InteropServices.Out> ByRef result As Object) As Boolean

    '    'Public Const SaleNo As String = "Sale No."
    '    'Public Const ReceiptNo As String = "Receipt Number"
    '    'Public Const TransValue As String = "Transaction Value"
    '    'Public Const FilterValue As String = "Filter Value"
    '    'Public Const DateAndTime As String = "Date/Time"
    '    'Public Const OperatorName As String = "Operator"
    '    'Public Const Tenders As String = "Tenders"

    '    Select Case binder.Name
    '        'Case "RowNum"
    '        '    result = TransactionColumnConstants.SaleNo
    '        '    Return True
    '        'Case "ReceiptNumber"
    '        '    result = TransactionColumnConstants.ReceiptNo
    '        '    Return True
    '        'Case "TransactionValue"
    '        '    result = TransactionColumnConstants.TransValue
    '        '    Return True
    '        Case strFilterName
    '            result = Data
    '            Return True
    '        Case Else
    '            Return MyBase.TryGetMember(binder, result)

    '    End Select

    '    'If binder.Name = "FilterValue" Then
    '    '    result = strFilterName
    '    '    Return True
    '    'End If

    '    'Return MyBase.TryGetMember(binder, result)
    'End Function

    <JsonProperty(PropertyName:=TransactionColumnConstants.SaleNo)>
    Property RowNum As Integer?

    <JsonProperty(PropertyName:=TransactionColumnConstants.ReceiptNo)>
    Property ReceiptNumber As String

    <JsonProperty(PropertyName:=TransactionColumnConstants.Reference)>
    Property Reference As String

    <JsonProperty(PropertyName:=TransactionColumnConstants.CustomerName)>
    Property CustomerName As String

    <JsonProperty(PropertyName:=TransactionColumnConstants.CustomerType)>
    Property CustomerType As String

    <JsonProperty(PropertyName:=TransactionColumnConstants.TransValue)>
    Property TransactionValue As Decimal

    <JsonProperty(PropertyName:=TransactionColumnConstants.FilterValue)>
    Property FilterValue As Decimal

    <JsonProperty(PropertyName:=TransactionColumnConstants.DateAndTime)>
    Property DateTime As DateTime?

    <JsonProperty(PropertyName:=TransactionColumnConstants.OperatorName)>
    Property OperatorName As String

    <JsonProperty(PropertyName:=TransactionColumnConstants.Tenders)>
    Property Tenders As String

    '<JsonProperty(PropertyName:=TransactionColumnConstants.AuthCode)>
    'Property AuthCode As String

End Class

Public Class clsCashingUpData
    Property columns As IEnumerable(Of IEnumerable(Of clsCashingUpColumn))
    'Property SummaryInfo As IEnumerable(Of clsCashingUpSummaryCell)
    Property data As IEnumerable(Of DataTable)
    'Property Transactions As IEnumerable(Of clsCashingUpTransaction)
End Class

Public Class clsCashingUpBreakdown
    'Property Columns As IEnumerable(Of clsCashingUpColumn)
    'Property SummaryInfo As IEnumerable(Of clsCashingUpSummaryCell)
    'Property data As DataTable
    Property columns As IEnumerable(Of IEnumerable(Of clsCashingUpColumn))
    Property data As IEnumerable(Of IEnumerable(Of clsCashingUpTransaction))

    Sub AddSummary()
        Dim lst As List(Of clsCashingUpTransaction) = data(0)
        Dim summary_array As New List(Of clsCashingUpTransaction)
        Dim summary As New clsCashingUpTransaction

        summary.FilterValue = lst.Sum(Function(x) x.FilterValue)
        summary.TransactionValue = lst.Sum(Function(x) x.TransactionValue)
        summary_array.Add(summary)
        data = {lst, summary_array}

    End Sub
End Class