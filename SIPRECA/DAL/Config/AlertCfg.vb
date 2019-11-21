Imports System.Data.Entity.ModelConfiguration
Public Class AlertCfg
    Inherits EntityTypeConfiguration(Of Alert)

    Public Sub New()
        Me.ToTable("Alert")
        Me.Property(Function(p) p.Contenu).IsRequired().HasMaxLength(5000)
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub

End Class
