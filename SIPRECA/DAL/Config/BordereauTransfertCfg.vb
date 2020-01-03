Imports System.Data.Entity.ModelConfiguration

Public Class BordereauTransfertCfg
    Inherits EntityTypeConfiguration(Of BordereauTransfert)
    Public Sub New()
        Me.ToTable("BordereauTransfert")
        Me.Property(Function(p) p.Id).IsRequired()
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.NumeroBordereau).IsOptional().HasMaxLength(100)
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.DateTransfert).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
