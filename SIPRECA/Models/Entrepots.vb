Partial Public Class Entrepots
    Public Sub New()
        Article = New HashSet(Of Article)()
        DemandeDArticle = New HashSet(Of DemandeDArticle)()
    End Sub

    Public Property Id As Long
    Public Property OganisationId As Long
    Public Property AdresseId As Long

    Public Property Nom As String
    Public Property Telephone As String
    Public Property CodePostale As String
    Public Property Email As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Adresse As Adresse
    Public Overridable Property Article As ICollection(Of Article)
    Public Overridable Property DemandeDArticle As ICollection(Of DemandeDArticle)
    Public Overridable Property Oganisation As Organisation
End Class
