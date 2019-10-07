Imports System.Data.Entity.ModelConfiguration
Public Class AutreImpactHumainEtEconomiqueCfg
    Inherits EntityTypeConfiguration(Of AutreImpactHumainEtEconomique)
    Public Sub New()
        Me.ToTable("AutreImpactHumainEtEconomique")
        Me.Property(Function(p) p.EvenementZoneId).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
