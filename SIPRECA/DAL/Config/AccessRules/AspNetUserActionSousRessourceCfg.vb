Imports System.Data.Entity.ModelConfiguration
Public Class AspNetUserActionSousRessourceCfg
    Inherits EntityTypeConfiguration(Of AspNetUserActionSousRessource)

    Public Sub New()
        Me.ToTable("AspNetUserActionSousRessource")
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
        Me.Property(Function(p) p.ActionSousRessourceId).IsRequired()
        Me.Property(Function(p) p.UserId).IsRequired()
    End Sub

End Class
