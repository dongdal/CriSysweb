Imports System.Data.Entity.ModelConfiguration
Public Class AdresseCfg
    Inherits EntityTypeConfiguration(Of Adresse)

    Public Sub New()
        Me.ToTable("Adresse")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Location).IsRequired()
        Me.Property(Function(p) p.CollectiviteId).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub

End Class
