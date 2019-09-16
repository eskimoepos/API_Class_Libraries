Public Class TenderArguments
    Implements iControllerArguments

    Property CreditCardTenders As FilterEnum = FilterEnum.Passive
    Property EskimoRangeTenders As FilterEnum = FilterEnum.Passive
    Property ActiveTenders As FilterEnum = FilterEnum.Enforce

End Class
