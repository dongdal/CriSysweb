
Partial Public Class HopitauxPuissance

    Public Property Id As Long
    Public Property HopitauxId As Long
    Public Property PuissanceId As Long

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Property Libelle As String

    Public Overridable Property Hopitaux As Hopitaux
    Public Overridable Property Puissance As Puissance
End Class
