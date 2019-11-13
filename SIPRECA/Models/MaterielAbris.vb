
Partial Public Class MaterielAbris
    Public Property Id As Long
    Public Property AbrisId As Long
    Public Property MaterielId As Long
    Public Property Quantite As Long

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Abris As Abris
    Public Overridable Property Materiel As Materiel
End Class
