Imports System.Data.Entity.ModelConfiguration

Public Class PrioriteCfg
    Inherits EntityTypeConfiguration(Of Priorite)
    Public Sub New()
        Me.ToTable("Priorite")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
