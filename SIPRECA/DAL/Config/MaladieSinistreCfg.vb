Imports System.Data.Entity.ModelConfiguration

Public Class MaladieSinistreCfg
    Inherits EntityTypeConfiguration(Of MaladieSinistre)
    Public Sub New()
        Me.ToTable("MaladieSinistre")
        Me.Property(Function(p) p.MaladieId).IsRequired()
        Me.Property(Function(p) p.SinistrerId).IsRequired()
        Me.Property(Function(p) p.AbrisId).IsRequired()
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
