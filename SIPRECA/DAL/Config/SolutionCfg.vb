Imports System.Data.Entity.ModelConfiguration

Public Class SolutionCfg
    Inherits EntityTypeConfiguration(Of Solution)
    Public Sub New()
        Me.ToTable("Solution")
        Me.Property(Function(p) p.TypeSolutionId).IsRequired()
        Me.Property(Function(p) p.EvenementZoneId).IsRequired()
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.AspNetUserId).IsRequired()

    End Sub
End Class
