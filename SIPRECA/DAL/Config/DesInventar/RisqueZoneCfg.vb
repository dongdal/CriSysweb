Imports System.Data.Entity.ModelConfiguration
Public Class RisqueZoneCfg
    Inherits EntityTypeConfiguration(Of RisqueZone)
    Public Sub New()
        Me.ToTable("RisqueZone")
        Me.Property(Function(p) p.RisqueId).IsRequired()
        Me.Property(Function(p) p.ZoneARisqueId).IsRequired()
        Me.Property(Function(p) p.NiveauDAlertId).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
