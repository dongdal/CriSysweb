Imports System.Data.Entity.ModelConfiguration

Public Class TypeOrganisationCfg
    Inherits EntityTypeConfiguration(Of TypeOrganisation)
    Public Sub New()
        Me.ToTable("TypeOrganisation")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
