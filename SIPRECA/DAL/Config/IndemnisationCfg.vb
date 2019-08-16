Imports System.Data.Entity.ModelConfiguration
Public Class IndemnisationCfg
    Inherits EntityTypeConfiguration(Of Indemnisation)
    Public Sub New()
        Me.ToTable("Indemnisation")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Description).IsOptional().HasMaxLength(4000)
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
