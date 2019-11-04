Imports System.Data.Entity.ModelConfiguration

Public Class MaterielEntrepotsCfg
    Inherits EntityTypeConfiguration(Of MaterielEntrepots)
    Public Sub New()
        Me.ToTable("MaterielEntrepots")
        Me.Property(Function(p) p.EntrepotsId).IsRequired()
        Me.Property(Function(p) p.MaterielId).IsRequired()
    End Sub
End Class
