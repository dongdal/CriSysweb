Imports System.Data.Entity.ModelConfiguration

Public Class MaterielHopitauxCfg
    Inherits EntityTypeConfiguration(Of MaterielHopitaux)
    Public Sub New()
        Me.ToTable("MaterielHopitaux")
        Me.Property(Function(p) p.HopitauxId).IsRequired()
        Me.Property(Function(p) p.MaterielId).IsRequired()
    End Sub
End Class
