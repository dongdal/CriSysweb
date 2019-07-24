Imports System.Data.Entity.ModelConfiguration
Public Class BureauCfg
    Inherits EntityTypeConfiguration(Of Bureau)
    Public Sub New()
        Me.ToTable("Bureau")
        Me.Property(Function(p) p.OganisationId).IsRequired()
        Me.Property(Function(p) p.TypeOfficeId).IsRequired()
        Me.Property(Function(p) p.AdresseId).IsRequired()
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.CodePostale).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Telephone).IsRequired().HasMaxLength(20)
        Me.Property(Function(p) p.Email).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.HeureDOuverture).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.HeureFermeture).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
