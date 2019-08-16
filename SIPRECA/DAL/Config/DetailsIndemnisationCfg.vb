Imports System.Data.Entity.ModelConfiguration
Public Class DetailsIndemnisationCfg
    Inherits EntityTypeConfiguration(Of DetailsIndemnisation)
    Public Sub New()
        Me.ToTable("DetailsIndemnisation")
        Me.Property(Function(p) p.Description).IsOptional().HasMaxLength(4000)
        Me.Property(Function(p) p.Quantite).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
