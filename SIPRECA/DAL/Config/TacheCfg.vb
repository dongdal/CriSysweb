Imports System.Data.Entity.ModelConfiguration

Public Class TacheCfg
    Inherits EntityTypeConfiguration(Of Tache)
    Public Sub New()
        Me.ToTable("Tache")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
