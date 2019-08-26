Imports System.Data.Entity.ModelConfiguration

Public Class HopitauxCfg
    Inherits EntityTypeConfiguration(Of Hopitaux)
    Public Sub New()
        Me.ToTable("Hopitaux")
        Me.Property(Function(p) p.OganisationId).IsRequired()
        Me.Property(Function(p) p.VilleId).IsRequired()
        Me.Property(Function(p) p.Location).IsOptional()
        Me.Property(Function(p) p.Code).IsRequired().HasMaxLength(5)
        Me.Property(Function(p) p.Nom).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Email).IsOptional().HasMaxLength(250)
        Me.Property(Function(p) p.Telephone).IsRequired().HasMaxLength(20)
        Me.Property(Function(p) p.TypeHopitauxId).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class