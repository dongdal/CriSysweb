Imports System.Data.Entity.ModelConfiguration

Public Class CommuneCfg
    Inherits EntityTypeConfiguration(Of Commune)
    Public Sub New()
        Me.ToTable("Commune")
        Me.Property(Function(p) p.Id).IsRequired()
    End Sub
End Class
