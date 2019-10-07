Imports System.Data.Entity.ModelConfiguration
Public Class EvenementZoneCfg
    Inherits EntityTypeConfiguration(Of EvenementZone)
    Public Sub New()
        Me.ToTable("EvenementZone")
        Me.Property(Function(p) p.ZoneARisqueId).IsRequired()
        Me.Property(Function(p) p.EvenementId).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
