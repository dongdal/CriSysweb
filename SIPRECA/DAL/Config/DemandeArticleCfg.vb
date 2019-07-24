Imports System.Data.Entity.ModelConfiguration

Public Class DemandeArticleCfg
    Inherits EntityTypeConfiguration(Of DemandeArticle)
    Public Sub New()
        Me.ToTable("DemandeArticle")
        Me.Property(Function(p) p.DemandeDArticleId).IsRequired()
        Me.Property(Function(p) p.ArticleId).IsRequired()
        Me.Property(Function(p) p.Quantite).IsRequired()
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
