Imports System.ComponentModel.DataAnnotations

''' <summary>
''' A class to specify filtering options for the data that is returned
''' </summary>
''' <remarks></remarks>
Public Class RecordSelection

    ''' <summary>
    ''' Initially, pass 1 to return the first record. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    <Range(1, Integer.MaxValue, ErrorMessage:="The Start Position must be 1 or greater")>
    Property StartPosition As Long = 1

    ''' <summary>
    ''' The number of records to be returned.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Required>
    <Range(1, 10000, ErrorMessage:="10,000 records is the maximum that can be returned at one time.")>
    Property RecordCount As Long = 20

End Class
