Imports System.Data.Entity.ModelConfiguration

Public Class SinistrerCfg
    Inherits EntityTypeConfiguration(Of Sinistrer)
    Public Sub New()
        Me.ToTable("Sinistrer")
        Me.Property(Function(p) p.Cni).IsRequired().HasMaxLength(30)
        Me.Property(Function(p) p.Nom).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Prenom).IsOptional().HasMaxLength(250)
        Me.Property(Function(p) p.Telephone).IsRequired().HasMaxLength(20)
        Me.Property(Function(p) p.Email).IsOptional().HasMaxLength(250)
        Me.Property(Function(p) p.DateDeNaissance).IsOptional()
        Me.Property(Function(p) p.Sexe).IsRequired().HasMaxLength(10)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class