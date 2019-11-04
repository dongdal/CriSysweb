Imports System.Data.Entity.ModelConfiguration

Public Class MaterielCfg
    Inherits EntityTypeConfiguration(Of Materiel)
    Public Sub New()
        Me.ToTable("Materiel")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Cible).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
