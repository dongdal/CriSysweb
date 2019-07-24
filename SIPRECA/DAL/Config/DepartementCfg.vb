Imports System.Data.Entity.ModelConfiguration

Public Class DepartementCfg
    Inherits EntityTypeConfiguration(Of Departement)
    Public Sub New()
        Me.ToTable("Departement")
        Me.Property(Function(p) p.ChefLieu).IsRequired().HasMaxLength(250)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
