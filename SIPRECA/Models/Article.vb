
Partial Public Class Article
    Public Sub New()
        DemandeArticle = New HashSet(Of DemandeArticle)()
    End Sub

    Public Property Id As Long
    Public Property EntrepotsId As Long
    Public Property CategorieDArticleId As Long

    Public Property Code As String
    Public Property Nom As String

    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property CategorieDArticle As CategorieDArticle
    Public Overridable Property Entrepots As Entrepots
    Public Overridable Property DemandeArticle As ICollection(Of DemandeArticle)
End Class
