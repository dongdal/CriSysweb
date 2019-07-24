Imports System.Data.Entity.ModelConfiguration

Public Class TypeAbrisCfg
    Inherits EntityTypeConfiguration(Of TypeAbris)
    Public Sub New()
        Me.ToTable("TypeAbris")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
