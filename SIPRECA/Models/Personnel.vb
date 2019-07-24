
Partial Public Class Personnel
    Public Sub New()
        Competance = New HashSet(Of Competance)()
        DemandeDArticle = New HashSet(Of DemandeDArticle)()
        PersonnelProjet = New HashSet(Of PersonnelProjet)()
        Taches = New HashSet(Of Tache)()
    End Sub

    Public Property Id As Long
    Public Property TypePersonnelId As Long
    Public Property OganisationId As Long
    Public Property Cni As String
    Public Property Nom As String
    Public Property Prenom As String
    Public Property Telephone As String
    Public Property Email As String
    Public Property DateDeNaissance As Date
    Public Property LieuNaissance As String
    Public Property Sexe As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Competance As ICollection(Of Competance)
    Public Overridable Property DemandeDArticle As ICollection(Of DemandeDArticle)
    Public Overridable Property Oganisation As Organisation
    Public Overridable Property PersonnelProjet As ICollection(Of PersonnelProjet)
    Public Overridable Property TypePersonnel As TypePersonnel
    Public Overridable Property Taches As ICollection(Of Tache)
End Class
