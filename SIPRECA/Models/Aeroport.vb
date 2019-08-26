
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Aeroport


    Public Property Id As Long
    Public Property OganisationId As Long
    Public Property VilleId As Long?
    Public Property SurfaceDePisteId As Long?
    Public Property TailleDeAeronefId As Long?
    Public Property UsageHumanitaireId As Long?

    Public Property Nom As String
    Public Property ICAO As String
    Public Property IATA As String
    Public Property LongueurDePiste As Double
    Public Property LargeurDePiste As Double
    Public Property Telephone As String
    Public Property Telephone2 As String
    Public Property SiteWeb As String
    Public Property Email As String
    Public Property Location As DbGeography


    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser


    Public Overridable Property Ville As Ville
    Public Overridable Property SurfaceDePiste As SurfaceDePiste
    Public Overridable Property TailleDeAeronef As TailleDeAeronef
    Public Overridable Property UsageHumanitaire As UsageHumanitaire
    Public Overridable Property Oganisation As Organisation
End Class
