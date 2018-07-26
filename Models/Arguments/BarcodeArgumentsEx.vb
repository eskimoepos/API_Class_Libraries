Public Class BarcodeArgumentsEx
    Inherits EskimoBaseClass
    Implements iControllerArguments

    Sub New()

    End Sub

    Property Barcode As BarcodeArguments

    Sub New(args As BarcodeArguments)
        Barcode = args.Clone
    End Sub


End Class
