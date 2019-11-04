Imports System.Data.Entity.ModelConfiguration

Public Class MaterielAeroportCfg
    Inherits EntityTypeConfiguration(Of MaterielAeroport)
    Public Sub New()
        Me.ToTable("MaterielAeroport")
        Me.Property(Function(p) p.AeroportId).IsRequired()
        Me.Property(Function(p) p.MaterielId).IsRequired()
    End Sub
End Class
