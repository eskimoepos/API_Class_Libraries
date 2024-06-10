Public Class clsReceipt
    Property Id As Integer
    Property Type As ReceiptTypeEnum
    Property Lines As List(Of String)
End Class

Public Enum ReceiptTypeEnum
    Sale = 0
    PaidIn = 1
    PaidOut = 2
    VoidAll = 3
    XRead = 4
    ZRead = 5
    RefundSlip = 6
    CreditNote = 7
    TillLiftDocket = 8
    AccountPayment = 9
    CustomerOrderNote = 10
    CustomerQuote = 11
    MailOrderNote = 12
    StockedItemsDocket = 13
    EFTMerchantReceipt = 14
    EFTCustomerReceipt = 15
End Enum