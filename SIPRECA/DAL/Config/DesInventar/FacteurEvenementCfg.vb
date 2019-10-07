Imports System.Data.Entity.ModelConfiguration
Public Class FacteurEvenementCfg
    Inherits EntityTypeConfiguration(Of FacteurEvenement)
    Public Sub New()
        Me.ToTable("FacteurEvenement")
        Me.Property(Function(p) p.FacteurId).IsRequired()
        Me.Property(Function(p) p.EvenementId).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
