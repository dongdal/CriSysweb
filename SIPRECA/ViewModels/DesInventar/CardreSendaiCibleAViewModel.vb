Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class CardreSendaiCibleAViewModel

    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="EvenementZoneId", ResourceType:=GetType(Resource))>
    Public Property EvenementZoneId As Long
    Public Overridable Property EvenementZone As EvenementZone
    Public Overridable Property LesEvenementsZone As ICollection(Of SelectListItem)

    <Display(Name:="NombreTotalDeces", ResourceType:=GetType(Resource))>
    Public Property NombreTotalDeces As Long?

    <Display(Name:="NombreDecesFemme", ResourceType:=GetType(Resource))>
    Public Property NombreDecesFemme As Long?

    <Display(Name:="NombreDecesHomme", ResourceType:=GetType(Resource))>
    Public Property NombreDecesHomme As Long?

    <Display(Name:="NombreDecesEnfant", ResourceType:=GetType(Resource))>
    Public Property NombreDecesEnfant As Long?

    <Display(Name:="NombreDecesAdult", ResourceType:=GetType(Resource))>
    Public Property NombreDecesAdult As Long?

    <Display(Name:="NombreDecesVieux", ResourceType:=GetType(Resource))>
    Public Property NombreDecesVieux As Long?

    <Display(Name:="NombreDecesHandicape", ResourceType:=GetType(Resource))>
    Public Property NombreDecesHandicape As Long?

    <Display(Name:="NombreDecesPauvre", ResourceType:=GetType(Resource))>
    Public Property NombreDecesPauvre As Long?

    <Display(Name:="NombreTotalDisparue", ResourceType:=GetType(Resource))>
    Public Property NombreTotalDisparue As Long?

    <Display(Name:="NombreDisparueFemme", ResourceType:=GetType(Resource))>
    Public Property NombreDisparueFemme As Long?

    <Display(Name:="NombreDisparueHomme", ResourceType:=GetType(Resource))>
    Public Property NombreDisparueHomme As Long?

    <Display(Name:="NombreDisparueEnfant", ResourceType:=GetType(Resource))>
    Public Property NombreDisparueEnfant As Long?

    <Display(Name:="NombreDisparueAdult", ResourceType:=GetType(Resource))>
    Public Property NombreDisparueAdult As Long?

    <Display(Name:="NombreDisparueVieux", ResourceType:=GetType(Resource))>
    Public Property NombreDisparueVieux As Long?

    <Display(Name:="NombreDisparueHandicape", ResourceType:=GetType(Resource))>
    Public Property NombreDisparueHandicape As Long?

    <Display(Name:="NombreDisparuePauvre", ResourceType:=GetType(Resource))>
    Public Property NombreDisparuePauvre As Long?

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

    Public Sub New(entity As CardreSendaiCibleA)
        With Me
            .Id = entity.Id
            .EvenementZoneId = entity.EvenementZoneId
            .EvenementZone = entity.EvenementZone
            .NombreTotalDeces = entity.NombreTotalDeces
            .NombreDecesFemme = entity.NombreDecesFemme
            .NombreDecesHomme = entity.NombreDecesHomme
            .NombreDecesEnfant = entity.NombreDecesEnfant
            .NombreDecesAdult = entity.NombreDecesAdult
            .NombreDecesVieux = entity.NombreDecesVieux
            .NombreDecesHandicape = entity.NombreDecesHandicape
            .NombreDecesPauvre = entity.NombreDecesPauvre
            .NombreTotalDisparue = entity.NombreTotalDisparue
            .NombreDisparueFemme = entity.NombreDisparueFemme
            .NombreDisparueHomme = entity.NombreDisparueHomme
            .NombreDisparueEnfant = entity.NombreDisparueEnfant
            .NombreDisparueAdult = entity.NombreDisparueAdult
            .NombreDisparueVieux = entity.NombreDisparueVieux
            .NombreDisparueHandicape = entity.NombreDisparueHandicape
            .NombreDisparuePauvre = entity.NombreDisparuePauvre
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As CardreSendaiCibleA
        Dim entity As New CardreSendaiCibleA
        With entity
            .Id = Id
            .EvenementZoneId = EvenementZoneId
            .NombreTotalDeces = NombreTotalDeces
            .NombreDecesFemme = NombreDecesFemme
            .NombreDecesHomme = NombreDecesHomme
            .NombreDecesEnfant = NombreDecesEnfant
            .NombreDecesAdult = NombreDecesAdult
            .NombreDecesVieux = NombreDecesVieux
            .NombreDecesHandicape = NombreDecesHandicape
            .NombreDecesPauvre = NombreDecesPauvre
            .NombreTotalDisparue = NombreTotalDisparue
            .NombreDisparueFemme = NombreDisparueFemme
            .NombreDisparueHomme = NombreDisparueHomme
            .NombreDisparueEnfant = NombreDisparueEnfant
            .NombreDisparueAdult = NombreDisparueAdult
            .NombreDisparueVieux = NombreDisparueVieux
            .NombreDisparueHandicape = NombreDisparueHandicape
            .NombreDisparuePauvre = NombreDisparuePauvre
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class
