
Imports System.ComponentModel.DataAnnotations

Public Class clsOrderExt
    Inherits clsOrderBase(Of clsOrderItemExt)

    ''' <summary>
    ''' See api/Orders/StatusCodes
    ''' </summary>
    ''' <returns></returns>
    Property StatusID As Integer?

    ''' <summary>
    ''' The status text description of the order status. See api/Orders/StatusCodes
    ''' </summary>
    ''' <returns></returns>
    Property StatusDescription As String

    ''' <summary>
    ''' The date and time that the order was last updated in the eCommerce system. Use api/Orders/Update to change this.
    ''' </summary>
    ''' <returns></returns>
    Property LastWebUpdate As DateTime?

    ''' <summary>
    ''' See api/Orders/FulfilmentMethods
    ''' </summary>
    ''' <returns></returns>
    Property ShippingTypeID As Integer

    ''' <summary>
    ''' The name of the Fulfilment Method
    ''' </summary>
    ''' <returns></returns>
    Property ShippingTypeName As String

    ''' <summary>
    ''' The Customer's main details.
    ''' </summary>
    ''' <returns></returns>
    Property CustomerInfo As clsCustomer

    ''' <summary>
    ''' Shop Code that the order is assigned to. See api/Shops/All
    ''' </summary>
    ''' <returns></returns>
    <StringLength(3)>
    Property ShopID As String

    ''' <summary>
    ''' The name of the shop
    ''' </summary>
    ''' <returns></returns>
    <StringLength(50)>
    Property ShopName As String

    Public Overrides Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult)
        Dim lst As New List(Of ValidationContext)

        Return lst

    End Function

End Class