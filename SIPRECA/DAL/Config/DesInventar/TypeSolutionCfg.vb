Imports System.Data.Entity.ModelConfiguration

Public Class TypeSolutionCfg
    Inherits EntityTypeConfiguration(Of TypeSolution)
    Public Sub New()
        Me.ToTable("TypeSolution")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
