Imports System.Data.Entity.Spatial

Partial Public Class AutreImpactHumainEtEconomique
    Public Property Id As Long
    Public Property EvenementZoneId As Long
    Public Property NombreDePersonneEvacue As Long
    Public Property NombreDePersonneAffecter As Long
    Public Property NombreDePersonneDirrectementAffecter As Long
    Public Property NombreDePersonneRelocaliser As Long
    Public Property TotalPerteEconomiqueLocalDevise As Double
    Public Property TotalPerteEconomiqueDolar As Double
    Public Property AutrePerte As String
    Public Property AmpleurDuDanger As String

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property EvenementZone As EvenementZone
End Class
