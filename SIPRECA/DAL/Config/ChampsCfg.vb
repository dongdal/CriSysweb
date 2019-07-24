Imports System.Data.Entity.ModelConfiguration

Public Class ChampsCfg
    Inherits EntityTypeConfiguration(Of Champs)
    Public Sub New()
        Me.ToTable("Champs")
        Me.Property(Function(p) p.Id).IsRequired()
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
