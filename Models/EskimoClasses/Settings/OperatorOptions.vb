Public Class clsOperatorOptions
    Enum OperatorLoginEnum
        ''' <summary>
        ''' This option is turned off 
        ''' </summary>
        Off = 0

        ''' <summary>
        ''' The operator stays signed in until someone signs them out manually.
        ''' </summary>
        SignInOnce = 1

        ''' <summary>
        ''' The operator is signed off automatically at the end of each sale. They must log in again to perform another sale.
        ''' </summary>
        EachSale = 2
    End Enum

    Property OperatorLogin As OperatorLoginEnum = OperatorLoginEnum.SignInOnce

End Class
