Imports System.ComponentModel.DataAnnotations

Public Module modEnums

    Enum FilterEnum

        ''' <summary>
        ''' This value must be False
        ''' </summary>
        Exclude = 0

        ''' <summary>
        ''' This value must be True
        ''' </summary>
        Enforce = 1

        ''' <summary>
        ''' It doesn't matter, I will accept all values
        ''' </summary>
        Passive = 2
    End Enum

    Public Enum OrderPostActions
        Inserted = 1
        Viewed = 2
        Opened = 3
        Printed = 4
        <Display(Name:="Customer Contacted")>
        CustomerContacted = 5
        Dispatched = 6
        <Display(Name:="Fully Dispatched")>
        DispatchedFull = 7
        <Display(Name:="Partally Dispatched")>
        DispatchedPartial = 8
        Invoiced = 9
        Picking = 10
        Returned = 11
        <Display(Name:="Partally Returned")>
        ReturnedPartial = 12
        <Display(Name:="Returned Full")>
        ReturnedFull = 13
        Refunded = 14
        <Display(Name:="Partally Refunded")>
        RefundedPartial = 15
        <Display(Name:="Refunded Full")>
        RefundedFull = 16
        Canceled = 17
        Exchanged = 18
        <Display(Name:="Partally Exchanged")>
        ExchangedPartial = 19
        <Display(Name:="Exchanged Full")>
        ExchangedFull = 20
        <Display(Name:="Exchange Returned")>
        ExchangeReturned = 21
        <Display(Name:="Partally Exchange Returned")>
        ExchangeReturnedPartial = 22
        <Display(Name:="Exchange Declined")>
        ExchangeDeclined = 23
        <Display(Name:="Bottle Note Message Sent")>
        BottleNoteMessageSent = 24
        <Display(Name:="Bottle Note Message Received")>
        BottleNoteMessageReceived = 25
        <Display(Name:="Message Received")>
        NoteAdded = 26
        <Display(Name:="Note Edited")>
        NoteEdited = 27
        <Display(Name:="Items updated")>
        ItemsUpdate = 28
        <Display(Name:="Items added")>
        ItemsAdded = 29
        <Display(Name:="Items Removed")>
        ItemsRemoved = 30
    End Enum

End Module
