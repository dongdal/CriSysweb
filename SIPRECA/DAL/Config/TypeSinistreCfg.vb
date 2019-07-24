Imports System.Data.Entity.ModelConfiguration

Public Class TypeSinistreCfg
    Inherits EntityTypeConfiguration(Of TypeSinistre)
    Public Sub New()
        Me.ToTable("TypeSinistre")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
