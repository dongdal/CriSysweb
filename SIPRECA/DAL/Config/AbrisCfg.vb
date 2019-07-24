Imports System.Data.Entity.ModelConfiguration
Public Class AbrisCfg
    Inherits EntityTypeConfiguration(Of Abris)

    Public Sub New()
        Me.ToTable("Abris")
        Me.Property(Function(p) p.Nom).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.EstimationPopulation).IsRequired()
        Me.Property(Function(p) p.AdresseId).IsRequired()
        Me.Property(Function(p) p.TypeAbrisId).IsRequired()
        Me.Property(Function(p) p.OganisationId).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub

End Class
