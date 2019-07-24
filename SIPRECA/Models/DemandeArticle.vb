Partial Public Class DemandeArticle
    Public Property Id As Long
    Public Property ArticleId As Long
    Public Property DemandeDArticleId As Long
    Public Property Quantite As Integer

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Article As Article
    Public Overridable Property DemandeDArticle As DemandeDArticle

End Class
