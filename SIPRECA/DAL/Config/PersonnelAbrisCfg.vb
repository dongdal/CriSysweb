Imports System.Data.Entity.ModelConfiguration

Public Class PersonnelAbrisCfg
    Inherits EntityTypeConfiguration(Of PersonnelAbris)
    Public Sub New()
        Me.ToTable("PersonnelAbris")
        Me.Property(Function(p) p.PersonnelId).IsRequired()
        Me.Property(Function(p) p.AbrisId).IsRequired()
    End Sub
End Class
