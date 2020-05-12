Imports System.ComponentModel.DataAnnotations

Public Enum PostcodeLookupSupplierEnum
    None = 0
    SimplyPostcode = 1
    PostcodeAnywhere = 2
    Streetwise = 3
End Enum

Public Class AddressValidatorParams
    Inherits EskimoBaseClass

    <Required>
    Property PostCode As String

End Class

Public Class AddressValidatorManualParams
    Inherits AddressValidatorParams

    <Required>
    Property supplier As PostcodeLookupSupplierEnum = PostcodeLookupSupplierEnum.None
    Property password As String
End Class

Public Class AddressValidatorManualParamsByID
    Inherits AddressValidatorManualParams

    <Required>
    Property id As String
End Class
