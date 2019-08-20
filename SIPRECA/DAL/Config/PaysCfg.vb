Imports System.Data.Entity.ModelConfiguration
Public Class PaysCfg
    Inherits EntityTypeConfiguration(Of Pays)

    Public Sub New()
        Me.ToTable("Pays")
        Me.Property(Function(p) p.Code).IsRequired()
        Me.Property(Function(p) p.Alpha2).IsRequired().HasMaxLength(2)
        Me.Property(Function(p) p.Alpha3).IsRequired().HasMaxLength(3)
        Me.Property(Function(p) p.Nom_En_Gb).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Nom_Fr_Fr).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub

End Class
