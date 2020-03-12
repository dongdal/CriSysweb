Imports System.Data.Entity.ModelConfiguration
Public Class ActionsCfg
    Inherits EntityTypeConfiguration(Of Actions)

    Public Sub New()
        Me.ToTable("Actions")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Description).IsOptional().HasMaxLength(4000)
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub

End Class
