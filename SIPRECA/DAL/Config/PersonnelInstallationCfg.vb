Imports System.Data.Entity.ModelConfiguration

Public Class PersonnelInstallationCfg
    Inherits EntityTypeConfiguration(Of PersonnelInstallation)
    Public Sub New()
        Me.ToTable("PersonnelInstallation")
        Me.Property(Function(p) p.PersonnelId).IsRequired()
        Me.Property(Function(p) p.InstallationId).IsRequired()
    End Sub
End Class
