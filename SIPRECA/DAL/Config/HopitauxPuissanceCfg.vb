Imports System.Data.Entity.ModelConfiguration

Public Class HopitauxPuissanceCfg
    Inherits EntityTypeConfiguration(Of HopitauxPuissance)
    Public Sub New()
        Me.ToTable("HopitauxPuissance")
        Me.Property(Function(p) p.PuissanceId).IsRequired()
        Me.Property(Function(p) p.HopitauxId).IsRequired()
    End Sub
End Class
