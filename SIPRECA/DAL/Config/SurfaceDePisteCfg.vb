Imports System.Data.Entity.ModelConfiguration

Public Class SurfaceDePisteCfg
    Inherits EntityTypeConfiguration(Of SurfaceDePiste)
    Public Sub New()
        Me.ToTable("SurfaceDePiste")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
