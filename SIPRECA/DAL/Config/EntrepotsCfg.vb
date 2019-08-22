Imports System.Data.Entity.ModelConfiguration

Public Class EntrepotsCfg
    Inherits EntityTypeConfiguration(Of Entrepots)
    Public Sub New()
        Me.ToTable("Entrepots")
        Me.Property(Function(p) p.TypeEntrepotId).IsRequired()
    End Sub
End Class
