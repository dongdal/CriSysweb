Imports System.Data.Entity.ModelConfiguration
Public Class DesagregationRecoltesAgricoleCfg
    Inherits EntityTypeConfiguration(Of DesagregationRecoltesAgricole)
    Public Sub New()
        Me.ToTable("DesagregationRecoltesAgricole")
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
