﻿Imports System.Data.Entity.ModelConfiguration

Public Class SecteurProjetCfg
    Inherits EntityTypeConfiguration(Of SecteurProjet)
    Public Sub New()
        Me.ToTable("SecteurProjet")
        'Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        'Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
