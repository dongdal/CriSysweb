Imports System.Data.Entity.ModelConfiguration

Public Class PieceJointeCfg
    Inherits EntityTypeConfiguration(Of PieceJointe)
    Public Sub New()
        Me.ToTable("PieceJointe")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.Lien).IsOptional().HasMaxLength(4000)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
