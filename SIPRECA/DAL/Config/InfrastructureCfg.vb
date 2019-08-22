Imports System.Data.Entity.ModelConfiguration

Public Class InfrastructureCfg
    Inherits EntityTypeConfiguration(Of Infrastructure)
    Public Sub New()
        Me.ToTable("Infrastructure")
        Me.Property(Function(p) p.Nom).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Code).IsRequired().HasMaxLength(5)
        Me.Property(Function(p) p.Telephone).IsOptional().HasMaxLength(20)
        Me.Property(Function(p) p.CodePostale).IsOptional().HasMaxLength(20)
        Me.Property(Function(p) p.Email).IsOptional().HasMaxLength(250)
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
