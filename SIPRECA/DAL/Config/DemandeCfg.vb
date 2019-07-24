Imports System.Data.Entity.ModelConfiguration

Public Class DemandeCfg
    Inherits EntityTypeConfiguration(Of Demande)
    Public Sub New()
        Me.ToTable("Demande")
        Me.Property(Function(p) p.Id).IsRequired()
        Me.Property(Function(p) p.Reference).IsRequired().HasMaxLength(250)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
