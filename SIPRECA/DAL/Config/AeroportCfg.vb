Imports System.Data.Entity.ModelConfiguration

Public Class AeroportCfg
    Inherits EntityTypeConfiguration(Of Aeroport)
    Public Sub New()
        Me.ToTable("Aeroport")
        Me.Property(Function(p) p.OganisationId).IsRequired()
        Me.Property(Function(p) p.VilleId).IsRequired()
        Me.Property(Function(p) p.Location).IsOptional()
        Me.Property(Function(p) p.Nom).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Email).IsOptional().HasMaxLength(250)
        Me.Property(Function(p) p.Telephone).IsOptional().HasMaxLength(20)
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.IATA).IsOptional()
        Me.Property(Function(p) p.ICAO).IsOptional()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class