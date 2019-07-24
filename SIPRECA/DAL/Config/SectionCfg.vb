Imports System.Data.Entity.ModelConfiguration

Public Class SectionCfg
    Inherits EntityTypeConfiguration(Of Section)
    Public Sub New()
        Me.ToTable("Section")
        Me.Property(Function(p) p.Titre).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Description).IsOptional().HasMaxLength(10000)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
