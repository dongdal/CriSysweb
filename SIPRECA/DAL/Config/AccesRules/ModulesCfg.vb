Imports System.Data.Entity.ModelConfiguration
Public Class ModulesCfg
    Inherits EntityTypeConfiguration(Of Modules)

    Public Sub New()
        Me.ToTable("Modules")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Description).IsOptional().HasMaxLength(4000)
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub

End Class
