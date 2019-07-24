Imports System.Data.Entity.ModelConfiguration

Public Class MoyenCfg
    Inherits EntityTypeConfiguration(Of Moyen)
    Public Sub New()
        Me.ToTable("Moyen")
        Me.Property(Function(p) p.TypeMoyenId).IsRequired()
        Me.Property(Function(p) p.OganisationId).IsRequired()
        Me.Property(Function(p) p.Nom).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Description).IsOptional.HasMaxLength(4000)
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.Location).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
