Imports System.Data.Entity.ModelConfiguration

Public Class MaterielHeliportCfg
    Inherits EntityTypeConfiguration(Of MaterielHeliport)
    Public Sub New()
        Me.ToTable("MaterielHeliport")
        Me.Property(Function(p) p.HeliportId).IsRequired()
        Me.Property(Function(p) p.MaterielId).IsRequired()
    End Sub
End Class
