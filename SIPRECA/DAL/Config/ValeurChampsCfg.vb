Imports System.Data.Entity.ModelConfiguration

Public Class ValeurChampsCfg
    Inherits EntityTypeConfiguration(Of ValeurChamps)
    Public Sub New()
        Me.ToTable("ValeurChamps")
        Me.Property(Function(p) p.Valeur).IsRequired().HasMaxLength(10000)
        Me.Property(Function(p) p.CodeCollecte).IsRequired().HasMaxLength(128)
        Me.Property(Function(p) p.DateSynchronisation).IsRequired()
        Me.Property(Function(p) p.DateCollecte).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.Latitude).IsRequired().HasMaxLength(128)
        Me.Property(Function(p) p.Longitude).IsRequired().HasMaxLength(128)
    End Sub
End Class
