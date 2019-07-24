Imports System.Data.Entity.ModelConfiguration

Public Class TypeMoyenCfg
    Inherits EntityTypeConfiguration(Of TypeMoyen)
    Public Sub New()
        Me.ToTable("TypeMoyen")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
