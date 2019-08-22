Imports System.Data.Entity.ModelConfiguration

Public Class CategorieElementCfg
    Inherits EntityTypeConfiguration(Of CategorieElement)
    Public Sub New()
        Me.ToTable("CategorieElement")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
