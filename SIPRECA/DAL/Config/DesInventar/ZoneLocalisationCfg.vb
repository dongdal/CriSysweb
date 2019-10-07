Imports System.Data.Entity.ModelConfiguration
Public Class ZoneLocalisationCfg
    Inherits EntityTypeConfiguration(Of ZoneLocalisation)
    Public Sub New()
        Me.ToTable("ZoneLocalisation")
        Me.Property(Function(p) p.ZoneARisqueId).IsRequired()
        Me.Property(Function(p) p.QuartierId).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
