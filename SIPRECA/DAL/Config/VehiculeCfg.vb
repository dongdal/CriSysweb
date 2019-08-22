Imports System.Data.Entity.ModelConfiguration

Public Class VehiculeCfg
    Inherits EntityTypeConfiguration(Of Vehicule)
    Public Sub New()
        Me.ToTable("Vehicule")
        Me.Property(Function(p) p.TypeVehiculeId).IsRequired()

    End Sub
End Class
