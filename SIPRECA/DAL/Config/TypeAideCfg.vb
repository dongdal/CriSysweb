Imports System.Data.Entity.ModelConfiguration
Public Class TypeAideCfg
    Inherits EntityTypeConfiguration(Of TypeAide)
    Public Sub New()
        Me.ToTable("TypeAide")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
