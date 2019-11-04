Imports System.Data.Entity.ModelConfiguration

Public Class MaterielInstallationCfg
    Inherits EntityTypeConfiguration(Of MaterielInstallation)
    Public Sub New()
        Me.ToTable("MaterielInstallation")
        Me.Property(Function(p) p.InstallationId).IsRequired()
        Me.Property(Function(p) p.MaterielId).IsRequired()
    End Sub
End Class
