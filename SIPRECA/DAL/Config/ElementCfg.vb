Imports System.Data.Entity.ModelConfiguration

Public Class ElementCfg
    Inherits EntityTypeConfiguration(Of Element)
    Public Sub New()
        Me.ToTable("Element")
        Me.Property(Function(p) p.CategorieElementId).IsRequired()
        Me.Property(Function(p) p.DeviseId).IsOptional()
        Me.Property(Function(p) p.Code).IsRequired().HasMaxLength(5)
        Me.Property(Function(p) p.MarqueElementId).IsOptional()
        Me.Property(Function(p) p.DeviseId).IsOptional()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
