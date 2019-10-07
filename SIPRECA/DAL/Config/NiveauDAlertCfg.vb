﻿Imports System.Data.Entity.ModelConfiguration

Public Class NiveauDAlertCfg
    Inherits EntityTypeConfiguration(Of NiveauDAlert)
    Public Sub New()
        Me.ToTable("NiveauDAlert")
        Me.Property(Function(p) p.Libelle).IsRequired().HasMaxLength(250)
        Me.Property(Function(p) p.DateCreation).IsRequired()
        Me.Property(Function(p) p.StatutExistant).IsRequired()
        Me.Property(Function(p) p.AspNetUserId).IsRequired()
    End Sub
End Class
