Imports System.Data.Entity.ModelConfiguration

Public Class TypeChampsCfg
    Inherits EntityTypeConfiguration(Of TypeChamps)
    Public Sub New()
        Me.ToTable("TypeChamps")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
