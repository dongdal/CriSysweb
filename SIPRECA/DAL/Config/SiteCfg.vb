Imports System.Data.Entity.ModelConfiguration

Public Class SiteCfg
    Inherits EntityTypeConfiguration(Of Site)
    Public Sub New()
        Me.ToTable("Site")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
