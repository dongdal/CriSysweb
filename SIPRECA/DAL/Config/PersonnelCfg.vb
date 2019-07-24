Imports System.Data.Entity.ModelConfiguration

Public Class PersonnelCfg
    Inherits EntityTypeConfiguration(Of Personnel)
    Public Sub New()
        Me.ToTable("Personnel")
        Me.Property(Function(p) p.Cni).IsRequired().HasMaxLength(30)
        Me.Property(Function(p) p.Nom).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Prenom).IsOptional().HasMaxLength(250)
        Me.Property(Function(p) p.Telephone).IsRequired().HasMaxLength(20)
        Me.Property(Function(p) p.Email).IsOptional().HasMaxLength(250)
        Me.Property(Function(p) p.LieuNaissance).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.DateDeNaissance).IsRequired()
        Me.Property(Function(p) p.Sexe).IsRequired().HasMaxLength(10)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
