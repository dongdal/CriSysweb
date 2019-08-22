Imports System.Data.Entity.ModelConfiguration

Public Class TypeEntrepotCfg
    Inherits EntityTypeConfiguration(Of TypeEntrepot)
    Public Sub New()
        Me.ToTable("TypeEntrepot")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
