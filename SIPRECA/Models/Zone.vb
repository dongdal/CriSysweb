
Partial Public Class Zone

    Public Property Id As Long
    Public Property NiveauDeRepresentationId As Long
    Public Property SiteId As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property NiveauDeRepresentation As NiveauDeRepresentation
    Public Overridable Property Site As Site
End Class
