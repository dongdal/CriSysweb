Imports System.Data.Entity.ModelConfiguration
Public Class NatureAideCfg
    Inherits EntityTypeConfiguration(Of NatureAide)
    Public Sub New()
        Me.ToTable("NatureAide")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
