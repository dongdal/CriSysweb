Imports System.Data.Entity.ModelConfiguration

Public Class ProjetCfg
    Inherits EntityTypeConfiguration(Of Projet)
    Public Sub New()
        Me.ToTable("Projet")
        Me.Property(Function(p) p.Reference).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Nom).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Description).IsOptional().HasMaxLength(4000)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
