Imports System.Data.Entity.ModelConfiguration
Public Class CardreSendaiCibleCDfg
    Inherits EntityTypeConfiguration(Of CardreSendaiCibleD)
    Public Sub New()
        Me.ToTable("CardreSendaiCibleD")
        Me.Property(Function(p) p.EvenementZoneId).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
