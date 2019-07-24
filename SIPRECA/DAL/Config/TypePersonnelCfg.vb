Imports System.Data.Entity.ModelConfiguration

Public Class TypePersonnelCfg
    Inherits EntityTypeConfiguration(Of TypePersonnel)
    Public Sub New()
        Me.ToTable("TypePersonnel")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
