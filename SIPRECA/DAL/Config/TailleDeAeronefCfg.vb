Imports System.Data.Entity.ModelConfiguration

Public Class TailleDeAeronefCfg
    Inherits EntityTypeConfiguration(Of TailleDeAeronef)
    Public Sub New()
        Me.ToTable("TailleDeAeronef")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
