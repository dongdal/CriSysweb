Imports System.Data.Entity.ModelConfiguration
Public Class QuartierCfg
    Inherits EntityTypeConfiguration(Of Quartier)
    Public Sub New()
        Me.ToTable("Quartier")
        Me.Property(Function(p) p.Id).IsRequired()
    End Sub
End Class
