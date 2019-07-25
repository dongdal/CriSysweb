Imports System.Data.Entity.ModelConfiguration

Public Class CollectiviteSinistreeCfg
    Inherits EntityTypeConfiguration(Of CollectiviteSinistree)
    Public Sub New()
        Me.ToTable("CollectiviteSinistree")
        Me.Property(Function(p) p.Id).IsRequired()
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.DateSinistre).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
