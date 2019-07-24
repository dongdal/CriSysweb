Imports System.Data.Entity.ModelConfiguration

Public Class ChampsSectionCfg
    Inherits EntityTypeConfiguration(Of ChampsSection)
    Public Sub New()
        Me.ToTable("ChampsSection")
        Me.Property(Function(p) p.Id).IsRequired()
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
