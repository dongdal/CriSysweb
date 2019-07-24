Imports System.Data.Entity.ModelConfiguration

Public Class CollectiviteCfg
    Inherits EntityTypeConfiguration(Of Collectivite)
    Public Sub New()
        Me.ToTable("Collectivite")
        Me.Property(Function(p) p.Id).IsRequired()
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
