Imports System.Data.Entity.ModelConfiguration
Public Class CardreSendaiCibleBCfg
    Inherits EntityTypeConfiguration(Of CardreSendaiCibleB)
    Public Sub New()
        Me.ToTable("CardreSendaiCibleB")
        Me.Property(Function(p) p.EvenementZoneId).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
