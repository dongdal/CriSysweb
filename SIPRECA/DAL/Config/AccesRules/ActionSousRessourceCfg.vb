Imports System.Data.Entity.ModelConfiguration
Public Class ActionSousRessourceCfg
    Inherits EntityTypeConfiguration(Of ActionSousRessource)

    Public Sub New()
        Me.ToTable("ActionSousRessource")
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub

End Class
