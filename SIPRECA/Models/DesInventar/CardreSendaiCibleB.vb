Imports System.Data.Entity.Spatial

Partial Public Class CardreSendaiCibleB
    Public Property Id As Long
    Public Property EvenementZoneId As Long
    Public Property NombreTotalBlesse As Long?
    Public Property NombreBlesseFemme As Long?
    Public Property NombreBlesseHomme As Long?
    Public Property NombreBlesseEnfant As Long?
    Public Property NombreBlesseAdult As Long?
    Public Property NombreBlesseVieux As Long?
    Public Property NombreBlesseHandicape As Long?
    Public Property NombreBlessePauvre As Long?
    Public Property NombreTotalMaisonEndomage As Long?
    Public Property NombreTotalPersonneMaisonEndomage As Long?
    Public Property NombreMaisonEndomageFemme As Long?
    Public Property NombreMaisonEndomageHomme As Long?
    Public Property NombreMaisonEndomageEnfant As Long?
    Public Property NombreMaisonEndomageAdult As Long?
    Public Property NombreMaisonEndomageVieux As Long?
    Public Property NombreMaisonEndomageHandicape As Long?
    Public Property NombreMaisonEndomagePauvre As Long?
    Public Property NombreTotalMaisonDetruite As Long?
    Public Property NombreTotalPersonneMaisonDetruite As Long?
    Public Property NombreMaisonDetruiteFemme As Long?
    Public Property NombreMaisonDetruiteHomme As Long?
    Public Property NombreMaisonDetruiteEnfant As Long?
    Public Property NombreMaisonDetruiteAdult As Long?
    Public Property NombreMaisonDetruiteVieux As Long?
    Public Property NombreMaisonDetruiteHandicape As Long?
    Public Property NombreMaisonDetruitePauvre As Long?
    Public Property NombreTotalMoyenSubsistance As Long?
    Public Property NombreMoyenSubsistanceFemme As Long?
    Public Property NombreMoyenSubsistanceHomme As Long?
    Public Property NombreMoyenSubsistanceEnfant As Long?
    Public Property NombreMoyenSubsistanceAdult As Long?
    Public Property NombreMoyenSubsistanceVieux As Long?
    Public Property NombreMoyenSubsistanceHandicape As Long?
    Public Property NombreMoyenSubsistancePauvre As Long?
    Public Property Source As String

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property EvenementZone As EvenementZone
End Class
