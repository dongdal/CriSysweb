Imports System.Data.Entity.ModelConfiguration

Public Class InstallationCfg
    Inherits EntityTypeConfiguration(Of Installation)
    Public Sub New()
        Me.ToTable("Installation")

    End Sub
End Class