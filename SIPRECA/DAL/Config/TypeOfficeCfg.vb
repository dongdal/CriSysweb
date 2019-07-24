Imports System.Data.Entity.ModelConfiguration

Public Class TypeOfficeCfg
    Inherits EntityTypeConfiguration(Of TypeOffice)
    Public Sub New()
        Me.ToTable("TypeOffice")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
