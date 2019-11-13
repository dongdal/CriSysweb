
Partial Public Class MaterielEntrepots
    Public Property Id As Long
    Public Property EntrepotsId As Long
    Public Property MaterielId As Long
    Public Property Quantite As Long

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Entrepots As Entrepots
    Public Overridable Property Materiel As Materiel
End Class
