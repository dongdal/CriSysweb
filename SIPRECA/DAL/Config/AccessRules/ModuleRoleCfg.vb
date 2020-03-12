Imports System.Data.Entity.ModelConfiguration
Public Class ModuleRoleCfg
    Inherits EntityTypeConfiguration(Of ModuleRole)

    Public Sub New()
        Me.ToTable("ModuleRole")
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub

End Class
