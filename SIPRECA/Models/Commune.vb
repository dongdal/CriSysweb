Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Commune
    Inherits Collectivite

    Public Property DepartementId As Long

    'Public Overridable Property Collectivite As Collectivite
    Public Overridable Property Departement As Departement
End Class
