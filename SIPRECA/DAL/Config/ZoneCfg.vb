Imports System.Data.Entity.ModelConfiguration

Public Class ZoneCfg
    Inherits EntityTypeConfiguration(Of Zone)
    Public Sub New()
        Me.ToTable("Zone")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Id).IsRequired()
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
