Imports System.Data.Entity.ModelConfiguration

Public Class ImmobilisationCfg
    Inherits EntityTypeConfiguration(Of Immobilisation)
    Public Sub New()
        Me.ToTable("Immobilisation")
        Me.Property(Function(p) p.ElementId).IsRequired()
        Me.Property(Function(p) p.NumeroImobilisation).IsRequired().HasMaxLength(20)
        Me.Property(Function(p) p.FournisseurId).IsRequired()
        Me.Property(Function(p) p.TypeImmobilisationId).IsOptional()
        Me.Property(Function(p) p.DeviseId).IsOptional()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
