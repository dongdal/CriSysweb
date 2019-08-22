Imports System.Data.Entity.ModelConfiguration
Public Class BureauCfg
    Inherits EntityTypeConfiguration(Of Bureau)
    Public Sub New()
        Me.ToTable("Bureau")
        Me.Property(Function(p) p.TypeOfficeId).IsRequired()

    End Sub
End Class
