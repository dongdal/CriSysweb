Imports System.Data.Entity.ModelConfiguration

Public Class MaterielPortDeMerCfg
    Inherits EntityTypeConfiguration(Of MaterielPortDeMer)
    Public Sub New()
        Me.ToTable("MaterielPortDeMer")
        Me.Property(Function(p) p.PortDeMerId).IsRequired()
        Me.Property(Function(p) p.MaterielId).IsRequired()
    End Sub
End Class
