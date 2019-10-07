Imports System.Data.Entity.ModelConfiguration
Public Class PerteBetailCfg
    Inherits EntityTypeConfiguration(Of PerteBetail)
    Public Sub New()
        Me.ToTable("PerteBetail")
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
