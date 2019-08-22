Imports System.Data.Entity.ModelConfiguration

Public Class TypeImmobilisationCfg
    Inherits EntityTypeConfiguration(Of TypeImmobilisation)
    Public Sub New()
        Me.ToTable("TypeImmobilisation")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
