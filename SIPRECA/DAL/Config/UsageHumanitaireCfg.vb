Imports System.Data.Entity.ModelConfiguration

Public Class UsageHumanitaireCfg
    Inherits EntityTypeConfiguration(Of UsageHumanitaire)
    Public Sub New()
        Me.ToTable("UsageHumanitaire")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
