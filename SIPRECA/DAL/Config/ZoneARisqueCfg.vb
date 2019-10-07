Imports System.Data.Entity.ModelConfiguration
Public Class ZoneARisqueCfg
    Inherits EntityTypeConfiguration(Of ZoneARisque)
    Public Sub New()
        Me.ToTable("ZoneARisque")
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
