Imports System.Data.Entity.ModelConfiguration

Public Class PersonnelBureauCfg
    Inherits EntityTypeConfiguration(Of PersonnelBureau)
    Public Sub New()
        Me.ToTable("PersonnelBureau")
        Me.Property(Function(p) p.PersonnelId).IsRequired()
        Me.Property(Function(p) p.BureauId).IsRequired()
    End Sub
End Class
