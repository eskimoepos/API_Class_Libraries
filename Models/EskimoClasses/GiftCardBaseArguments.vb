﻿Imports System.ComponentModel.DataAnnotations

Public Class GiftCardBaseArgument

    <Required>
    Property CardNumber As String

    <Required>
    <StringLength(3, ErrorMessage:="The StoreNumber must be 3 digits.", MinimumLength:=3)>
    Property StoreNumber As String
End Class
