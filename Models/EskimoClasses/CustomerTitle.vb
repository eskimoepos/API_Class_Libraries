''' <summary>
''' The Customer Titles Class. This stores the types of title a person can have. i.e. Mr., Mrs., Miss., Dr. etc.
''' </summary>
Public Class clsCustomerTitle

    Inherits EskimoBaseClass

    ''' <summary>
    ''' The Eskimo-generated ID for this customer title
    ''' </summary>
    ''' <returns></returns>
    Property TitleID As Integer
    ''' <summary>
    ''' The value of this customer title. i.e. Mr., Mrs., Miss., Dr. etc.
    ''' </summary>
    ''' <returns></returns>
    Property TitleValue As String

    ''' <summary>
    ''' If the title should be displayed for new customers. Historic inactive ones may still be joined to existing customers.
    ''' </summary>
    ''' <returns></returns>
    Property Active As Boolean


End Class
