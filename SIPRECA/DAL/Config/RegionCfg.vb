Imports System.Data.Entity.ModelConfiguration

Public Class RegionCfg
    Inherits EntityTypeConfiguration(Of Region)
    Public Sub New()
        Me.ToTable("Region")
        Me.Property(Function(p) p.Id).IsRequired()
    End Sub
End Class
