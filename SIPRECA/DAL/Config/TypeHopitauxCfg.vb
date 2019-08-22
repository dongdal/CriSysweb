Imports System.Data.Entity.ModelConfiguration

Public Class TypeHopitauxCfg
    Inherits EntityTypeConfiguration(Of TypeHopitaux)
    Public Sub New()
        Me.ToTable("TypeHopitaux")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
