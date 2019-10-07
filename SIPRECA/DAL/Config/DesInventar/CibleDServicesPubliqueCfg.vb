Imports System.Data.Entity.ModelConfiguration
Public Class CibleDServicesPubliqueCfg
    Inherits EntityTypeConfiguration(Of CibleDServicesPublique)
    Public Sub New()
        Me.ToTable("CibleDServicesPublique")
        Me.Property(Function(p) p.ServicesPubliquePertubeId).IsRequired()
        Me.Property(Function(p) p.CardreSendaiCibleDId).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
