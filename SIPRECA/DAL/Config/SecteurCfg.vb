Imports System.Data.Entity.ModelConfiguration

Public Class SecteurCfg
    Inherits EntityTypeConfiguration(Of Secteur)
    Public Sub New()
        Me.ToTable("Secteur")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
