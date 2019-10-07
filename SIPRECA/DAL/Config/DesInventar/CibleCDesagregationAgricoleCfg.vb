Imports System.Data.Entity.ModelConfiguration
Public Class CibleCDesagregationAgricoleCfg
    Inherits EntityTypeConfiguration(Of CibleCDesagregationAgricole)
    Public Sub New()
        Me.ToTable("CibleCDesagregationAgricole")
        Me.Property(Function(p) p.DesagregationRecoltesAgricoleId).IsRequired()
        Me.Property(Function(p) p.CardreSendaiCibleCId).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
