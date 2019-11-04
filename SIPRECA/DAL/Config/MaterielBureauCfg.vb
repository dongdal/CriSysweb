Imports System.Data.Entity.ModelConfiguration

Public Class MaterielBureauCfg
    Inherits EntityTypeConfiguration(Of MaterielBureau)
    Public Sub New()
        Me.ToTable("MaterielBureau")
        Me.Property(Function(p) p.BureauId).IsRequired()
        Me.Property(Function(p) p.MaterielId).IsRequired()
    End Sub
End Class
