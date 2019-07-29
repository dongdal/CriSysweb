Imports System.Data.Entity.ModelConfiguration

Public Class PropositionCfg
    Inherits EntityTypeConfiguration(Of Proposition)
    Public Sub New()
        Me.ToTable("Proposition")
        Me.Property(Function(p) p.Id).IsRequired()
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(1000)


    End Sub
End Class
