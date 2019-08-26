Imports System.Data.Entity.ModelConfiguration

Public Class PortDeMerCfg
    Inherits EntityTypeConfiguration(Of PortDeMer)
    Public Sub New()
        Me.ToTable("PortDeMer")
        Me.Property(Function(p) p.OganisationId).IsRequired()
        Me.Property(Function(p) p.VilleId).IsRequired()
        Me.Property(Function(p) p.Location).IsOptional()
        Me.Property(Function(p) p.Code).IsRequired().HasMaxLength(5)
        Me.Property(Function(p) p.Nom).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Email).IsOptional().HasMaxLength(250)
        Me.Property(Function(p) p.Telephone).IsRequired().HasMaxLength(20)
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.Abri).IsOptional().HasMaxLength(4000)
        Me.Property(Function(p) p.Securite).IsOptional().HasMaxLength(4000)
        Me.Property(Function(p) p.EquipementChargement).IsOptional().HasMaxLength(4000)
        Me.Property(Function(p) p.Reparations).IsOptional().HasMaxLength(4000)
        Me.Property(Function(p) p.CapaciteDouaniere).IsOptional().HasMaxLength(4000)
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class