Imports System.Data.Entity.ModelConfiguration

Public Class PersonnelProjetCfg
    Inherits EntityTypeConfiguration(Of PersonnelProjet)
    Public Sub New()
        Me.ToTable("PersonnelProjet")
        Me.Property(Function(p) p.PersonnelId).IsRequired()
        Me.Property(Function(p) p.ProjetId).IsRequired()
    End Sub
End Class
