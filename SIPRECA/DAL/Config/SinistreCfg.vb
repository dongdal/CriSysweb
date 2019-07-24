Imports System.Data.Entity.ModelConfiguration

Public Class SinistreCfg
    Inherits EntityTypeConfiguration(Of Sinistre)
    Public Sub New()
        Me.ToTable("Sinistre")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
