﻿Imports System.Data.Entity.ModelConfiguration

Public Class SuiviCfg
    Inherits EntityTypeConfiguration(Of Suivi)
    Public Sub New()
        Me.ToTable("Suivi")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
