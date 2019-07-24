Imports System.Data.Entity.ModelConfiguration

Public Class ValeurChampsCfg
    Inherits EntityTypeConfiguration(Of ValeurChamps)
    Public Sub New()
        Me.ToTable("ValeurChamps")
        Me.Property(Function(p) p.Valeur).IsRequired().HasMaxLength(10000)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
