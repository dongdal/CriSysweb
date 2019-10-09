Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class CardreSendaiCibleBViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="EvenementZoneId", ResourceType:=GetType(Resource))>
    Public Property EvenementZoneId As Long
    Public Overridable Property EvenementZone As EvenementZone
    Public Overridable Property LesEvenementsZone As ICollection(Of SelectListItem)

    <Display(Name:="NombreTotalBlesse", ResourceType:=GetType(Resource))>
    Public Property NombreTotalBlesse As Long?

    <Display(Name:="NombreBlesseFemme", ResourceType:=GetType(Resource))>
    Public Property NombreBlesseFemme As Long?

    <Display(Name:="NombreBlesseHomme", ResourceType:=GetType(Resource))>
    Public Property NombreBlesseHomme As Long?

    <Display(Name:="NombreBlesseEnfant", ResourceType:=GetType(Resource))>
    Public Property NombreBlesseEnfant As Long?

    <Display(Name:="NombreBlesseAdult", ResourceType:=GetType(Resource))>
    Public Property NombreBlesseAdult As Long?

    <Display(Name:="NombreBlesseVieux", ResourceType:=GetType(Resource))>
    Public Property NombreBlesseVieux As Long?

    <Display(Name:="NombreBlesseHandicape", ResourceType:=GetType(Resource))>
    Public Property NombreBlesseHandicape As Long?

    <Display(Name:="NombreBlessePauvre", ResourceType:=GetType(Resource))>
    Public Property NombreBlessePauvre As Long?

    <Display(Name:="NombreTotalMaisonEndomage", ResourceType:=GetType(Resource))>
    Public Property NombreTotalMaisonEndomage As Long?

    <Display(Name:="NombreMaisonEndomageFemme", ResourceType:=GetType(Resource))>
    Public Property NombreMaisonEndomageFemme As Long?

    <Display(Name:="NombreMaisonEndomageHomme", ResourceType:=GetType(Resource))>
    Public Property NombreMaisonEndomageHomme As Long?

    <Display(Name:="NombreMaisonEndomageEnfant", ResourceType:=GetType(Resource))>
    Public Property NombreMaisonEndomageEnfant As Long?

    <Display(Name:="NombreMaisonEndomageAdult", ResourceType:=GetType(Resource))>
    Public Property NombreMaisonEndomageAdult As Long?

    <Display(Name:="NombreTotalDeces", ResourceType:=GetType(Resource))>
    Public Property NombreMaisonEndomageVieux As Long?

    <Display(Name:="NombreMaisonEndomageHandicape", ResourceType:=GetType(Resource))>
    Public Property NombreMaisonEndomageHandicape As Long?

    <Display(Name:="NombreMaisonEndomagePauvre", ResourceType:=GetType(Resource))>
    Public Property NombreMaisonEndomagePauvre As Long?

    <Display(Name:="NombreTotalMaisonDetruite", ResourceType:=GetType(Resource))>
    Public Property NombreTotalMaisonDetruite As Long?

    <Display(Name:="NombreMaisonDetruiteFemme", ResourceType:=GetType(Resource))>
    Public Property NombreMaisonDetruiteFemme As Long?

    <Display(Name:="NombreMaisonDetruiteHomme", ResourceType:=GetType(Resource))>
    Public Property NombreMaisonDetruiteHomme As Long?

    <Display(Name:="NombreMaisonDetruiteEnfant", ResourceType:=GetType(Resource))>
    Public Property NombreMaisonDetruiteEnfant As Long?

    <Display(Name:="NombreMaisonDetruiteAdult", ResourceType:=GetType(Resource))>
    Public Property NombreMaisonDetruiteAdult As Long?

    <Display(Name:="NombreMaisonDetruiteVieux", ResourceType:=GetType(Resource))>
    Public Property NombreMaisonDetruiteVieux As Long?

    <Display(Name:="NombreMaisonDetruiteHandicape", ResourceType:=GetType(Resource))>
    Public Property NombreMaisonDetruiteHandicape As Long?

    <Display(Name:="NombreMaisonDetruitePauvre", ResourceType:=GetType(Resource))>
    Public Property NombreMaisonDetruitePauvre As Long?

    <Display(Name:="NombreTotalMoyenSubsistance", ResourceType:=GetType(Resource))>
    Public Property NombreTotalMoyenSubsistance As Long?

    <Display(Name:="NombreMoyenSubsistanceFemme", ResourceType:=GetType(Resource))>
    Public Property NombreMoyenSubsistanceFemme As Long?

    <Display(Name:="NombreMoyenSubsistanceHomme", ResourceType:=GetType(Resource))>
    Public Property NombreMoyenSubsistanceHomme As Long?

    <Display(Name:="NombreMoyenSubsistanceEnfant", ResourceType:=GetType(Resource))>
    Public Property NombreMoyenSubsistanceEnfant As Long?

    <Display(Name:="NombreMoyenSubsistanceAdult", ResourceType:=GetType(Resource))>
    Public Property NombreMoyenSubsistanceAdult As Long?

    <Display(Name:="NombreMoyenSubsistanceVieux", ResourceType:=GetType(Resource))>
    Public Property NombreMoyenSubsistanceVieux As Long?

    <Display(Name:="NombreMoyenSubsistanceHandicape", ResourceType:=GetType(Resource))>
    Public Property NombreMoyenSubsistanceHandicape As Long?

    <Display(Name:="NombreMoyenSubsistancePauvre", ResourceType:=GetType(Resource))>
    Public Property NombreMoyenSubsistancePauvre As Long?

    <Display(Name:="DateCreation", ResourceType:=GetType(Resource))>
    Public Property DateCreation As DateTime = Now

    <Display(Name:="StatutExistant", ResourceType:=GetType(Resource))>
    Public Property StatutExistant As Short = 1

    <Display(Name:="Utilisateur", ResourceType:=GetType(Resource))>
    Public Property AspNetUserId As String
    Public Overridable Property LesUtilisateurs As ICollection(Of SelectListItem)
    Public Overridable Property AspNetUser As ApplicationUser

    Public Sub New()
    End Sub

    Public Sub New(entity As CardreSendaiCibleB)
        With Me
            .Id = entity.Id
            .EvenementZoneId = entity.EvenementZoneId
            .EvenementZone = entity.EvenementZone
            .NombreTotalBlesse = entity.NombreTotalBlesse
            .NombreBlesseFemme = entity.NombreBlesseFemme
            .NombreBlesseHomme = entity.NombreBlesseHomme
            .NombreBlesseEnfant = entity.NombreBlesseEnfant
            .NombreBlesseAdult = entity.NombreBlesseAdult
            .NombreBlesseVieux = entity.NombreBlesseVieux
            .NombreBlesseHandicape = entity.NombreBlesseHandicape
            .NombreBlessePauvre = entity.NombreBlessePauvre
            .NombreTotalMaisonEndomage = entity.NombreTotalMaisonEndomage
            .NombreMaisonEndomageFemme = entity.NombreMaisonEndomageFemme
            .NombreMaisonEndomageHomme = entity.NombreMaisonEndomageHomme
            .NombreMaisonEndomageEnfant = entity.NombreMaisonEndomageEnfant
            .NombreMaisonEndomageAdult = entity.NombreMaisonEndomageAdult
            .NombreMaisonEndomageVieux = entity.NombreMaisonEndomageVieux
            .NombreMaisonEndomageHandicape = entity.NombreMaisonEndomageHandicape
            .NombreMaisonEndomagePauvre = entity.NombreMaisonEndomagePauvre
            .NombreTotalMaisonDetruite = entity.NombreTotalMaisonDetruite
            .NombreMaisonDetruiteFemme = entity.NombreMaisonDetruiteFemme
            .NombreMaisonDetruiteHomme = entity.NombreMaisonDetruiteHomme
            .NombreMaisonDetruiteEnfant = entity.NombreMaisonDetruiteEnfant
            .NombreMaisonDetruiteAdult = entity.NombreMaisonDetruiteAdult
            .NombreMaisonDetruiteVieux = entity.NombreMaisonDetruiteVieux
            .NombreMaisonDetruiteHandicape = entity.NombreMaisonDetruiteHandicape
            .NombreMaisonDetruitePauvre = entity.NombreMaisonDetruitePauvre
            .NombreTotalMoyenSubsistance = entity.NombreTotalMoyenSubsistance
            .NombreMoyenSubsistanceFemme = entity.NombreMoyenSubsistanceFemme
            .NombreMoyenSubsistanceHomme = entity.NombreMoyenSubsistanceHomme
            .NombreMoyenSubsistanceEnfant = entity.NombreMoyenSubsistanceEnfant
            .NombreMoyenSubsistanceAdult = entity.NombreMoyenSubsistanceAdult
            .NombreMoyenSubsistanceVieux = entity.NombreMoyenSubsistanceVieux
            .NombreMoyenSubsistanceHandicape = entity.NombreMoyenSubsistanceHandicape
            .NombreMoyenSubsistancePauvre = entity.NombreMoyenSubsistancePauvre
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As CardreSendaiCibleB
        Dim entity As New CardreSendaiCibleB
        With entity

            .Id = Id
            .EvenementZoneId = EvenementZoneId
            .NombreTotalBlesse = NombreTotalBlesse
            .NombreBlesseFemme = NombreBlesseFemme
            .NombreBlesseHomme = NombreBlesseHomme
            .NombreBlesseEnfant = NombreBlesseEnfant
            .NombreBlesseAdult = NombreBlesseAdult
            .NombreBlesseVieux = NombreBlesseVieux
            .NombreBlesseHandicape = NombreBlesseHandicape
            .NombreBlessePauvre = NombreBlessePauvre
            .NombreTotalMaisonEndomage = NombreTotalMaisonEndomage
            .NombreMaisonEndomageFemme = NombreMaisonEndomageFemme
            .NombreMaisonEndomageHomme = NombreMaisonEndomageHomme
            .NombreMaisonEndomageEnfant = NombreMaisonEndomageEnfant
            .NombreMaisonEndomageAdult = NombreMaisonEndomageAdult
            .NombreMaisonEndomageVieux = NombreMaisonEndomageVieux
            .NombreMaisonEndomageHandicape = NombreMaisonEndomageHandicape
            .NombreMaisonEndomagePauvre = NombreMaisonEndomagePauvre
            .NombreTotalMaisonDetruite = NombreTotalMaisonDetruite
            .NombreMaisonDetruiteFemme = NombreMaisonDetruiteFemme
            .NombreMaisonDetruiteHomme = NombreMaisonDetruiteHomme
            .NombreMaisonDetruiteEnfant = NombreMaisonDetruiteEnfant
            .NombreMaisonDetruiteAdult = NombreMaisonDetruiteAdult
            .NombreMaisonDetruiteVieux = NombreMaisonDetruiteVieux
            .NombreMaisonDetruiteHandicape = NombreMaisonDetruiteHandicape
            .NombreMaisonDetruitePauvre = NombreMaisonDetruitePauvre
            .NombreTotalMoyenSubsistance = NombreTotalMoyenSubsistance
            .NombreMoyenSubsistanceFemme = NombreMoyenSubsistanceFemme
            .NombreMoyenSubsistanceHomme = NombreMoyenSubsistanceHomme
            .NombreMoyenSubsistanceEnfant = NombreMoyenSubsistanceEnfant
            .NombreMoyenSubsistanceAdult = NombreMoyenSubsistanceAdult
            .NombreMoyenSubsistanceVieux = NombreMoyenSubsistanceVieux
            .NombreMoyenSubsistanceHandicape = NombreMoyenSubsistanceHandicape
            .NombreMoyenSubsistancePauvre = NombreMoyenSubsistancePauvre
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class
