
Partial Public Class MaladieSinistre
    Public Property Id As Long
    Public Property MaladieId As Long
    Public Property SinistrerId As Long
    Public Property AbrisId As Long

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Abris As Abris
    Public Overridable Property Maladie As Maladie
    Public Overridable Property Sinistrer As Sinistrer
End Class
