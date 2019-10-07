Imports System.Data.Entity.ModelConfiguration
Public Class CibleCPerteBetailCfg
    Inherits EntityTypeConfiguration(Of CibleCPerteBetail)
    Public Sub New()
        Me.ToTable("CibleCPerteBetail")
        Me.Property(Function(p) p.PerteBetailId).IsRequired()
        Me.Property(Function(p) p.CardreSendaiCibleCId).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
