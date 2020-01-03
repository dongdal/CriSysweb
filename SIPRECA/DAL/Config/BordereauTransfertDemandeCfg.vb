Imports System.Data.Entity.ModelConfiguration

Public Class BordereauTransfertDemandeCfg
    Inherits EntityTypeConfiguration(Of BordereauTransfertDemande)
    Public Sub New()
        Me.ToTable("BordereauTransfertDemande")
        Me.Property(Function(p) p.Id).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
    End Sub
End Class
