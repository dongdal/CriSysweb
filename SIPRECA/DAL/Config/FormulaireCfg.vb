Imports System.Data.Entity.ModelConfiguration

Public Class FormulaireCfg
    Inherits EntityTypeConfiguration(Of Formulaire)
    Public Sub New()
        Me.ToTable("Formulaire")
        Me.Property(Function(p) p.Titre).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Description).IsOptional().HasMaxLength(4000)
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
