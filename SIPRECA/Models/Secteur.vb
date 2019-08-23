
Partial Public Class Secteur
    Public Sub New()
        SecteurProjet = New HashSet(Of SecteurProjet)()
    End Sub

    Public Property Id As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property SecteurProjet As ICollection(Of SecteurProjet)
End Class
