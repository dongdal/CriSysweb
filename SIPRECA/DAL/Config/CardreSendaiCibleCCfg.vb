Imports System.Data.Entity.ModelConfiguration
Public Class CardreSendaiCibleCCfg
    Inherits EntityTypeConfiguration(Of CardreSendaiCibleC)
    Public Sub New()
        Me.ToTable("CardreSendaiCibleC")
        Me.Property(Function(p) p.EvenementZoneId).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
