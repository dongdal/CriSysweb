Imports System.Data.Entity.ModelConfiguration
Public Class ArticleCfg
    Inherits EntityTypeConfiguration(Of Article)
    Public Sub New()
        Me.ToTable("Article")
        Me.Property(Function(p) p.Code).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Nom).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.CategorieDArticleId).IsRequired()
        Me.Property(Function(p) p.EntrepotsId).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
