Imports System.Data.Entity.ModelConfiguration

Public Class IndemmisationCfg
    Inherits EntityTypeConfiguration(Of Indemmisation)
    Public Sub New()
        Me.ToTable("Indemmisation")
        Me.Property(Function(p) p.DemandeId).IsRequired()
        Me.Property(Function(p) p.CollectiviteId).IsRequired()
        Me.Property(Function(p) p.Montant).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
