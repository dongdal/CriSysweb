Imports System.Data.Entity.ModelConfiguration
Public Class CardreSendaiCibleACfg
    Inherits EntityTypeConfiguration(Of CardreSendaiCibleA)
    Public Sub New()
        Me.ToTable("CardreSendaiCibleA")
        Me.Property(Function(p) p.EvenementZoneId).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
