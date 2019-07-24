Imports System.Data.Entity.ModelConfiguration
Public Class CausesCfg
    Inherits EntityTypeConfiguration(Of Causes)
    Public Sub New()
        Me.ToTable("Causes")
        Me.Property(Function(p) p.SinistreId).IsRequired()
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
