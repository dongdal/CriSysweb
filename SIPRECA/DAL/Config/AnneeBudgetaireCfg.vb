Imports System.Data.Entity.ModelConfiguration
Public Class AnneeBudgetaireCfg
    Inherits EntityTypeConfiguration(Of AnneeBudgetaire)
    Public Sub New()
        Me.ToTable("AnneeBudgetaire")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.DateDebut).IsRequired()
        Me.Property(Function(p) p.DateFin).IsRequired()
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
