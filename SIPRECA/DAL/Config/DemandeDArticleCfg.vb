Imports System.Data.Entity.ModelConfiguration

Public Class DemandeDArticleCfg
    Inherits EntityTypeConfiguration(Of DemandeDArticle)
    Public Sub New()
        Me.ToTable("DemandeDArticle")
        Me.Property(Function(p) p.Code).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Details).IsRequired().HasMaxLength(250)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
