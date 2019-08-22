Imports System.Data.Entity.ModelConfiguration

Public Class OrganisationCfg
    Inherits EntityTypeConfiguration(Of Organisation)
    Public Sub New()
        Me.ToTable("Organisation")
        Me.Property(Function(p) p.Id).IsRequired()
        Me.Property(Function(p) p.Nom).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Telephone).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.SiteWeb).HasMaxLength(250)
        Me.Property(Function(p) p.Email).HasMaxLength(250)
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.Email).IsRequired()
Me.Property(Function(p) p.AspNetUserId).IsRequired()

    End Sub
End Class
