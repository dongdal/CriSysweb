Imports System.Data.Entity.ModelConfiguration

Public Class CollecteCfg
    Inherits EntityTypeConfiguration(Of Collecte)
    Public Sub New()
        Me.ToTable("Collecte")
        Me.Property(Function(p) p.Id).IsRequired()
        Me.Property(Function(p) p.Valeur).IsOptional()
        Me.Property(Function(p) p.Latitude).IsOptional()
        Me.Property(Function(p) p.Longitude).IsOptional()
        Me.Property(Function(p) p.LibellePosition).IsOptional().HasMaxLength(250)
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.DateCollecte).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
