Imports System.Data.Entity.ModelConfiguration

Public Class PuissanceCfg
    Inherits EntityTypeConfiguration(Of Puissance)
    Public Sub New()
        Me.ToTable("Puissance")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
