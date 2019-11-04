Imports System.Data.Entity.ModelConfiguration

Public Class MaterielAbrisCfg
    Inherits EntityTypeConfiguration(Of MaterielAbris)
    Public Sub New()
        Me.ToTable("MaterielAbris")
        Me.Property(Function(p) p.AbrisId).IsRequired()
        Me.Property(Function(p) p.MaterielId).IsRequired()
    End Sub
End Class
