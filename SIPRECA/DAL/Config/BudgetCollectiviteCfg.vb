Imports System.Data.Entity.ModelConfiguration
Public Class BudgetCollectiviteCfg
    Inherits EntityTypeConfiguration(Of BudgetCollectivite)
    Public Sub New()
        Me.ToTable("BudgetCollectivite")
        Me.Property(Function(p) p.CollectiviteId).IsRequired()
        Me.Property(Function(p) p.AnneeBudgetaireId).IsRequired()
        Me.Property(Function(p) p.Montant).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
