Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class AutreImpactHumainEtEconomiqueViewModel

    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="EvenementZoneId", ResourceType:=GetType(Resource))>
    Public Property EvenementZoneId As Long
    Public Overridable Property EvenementZone As EvenementZone
    Public Overridable Property LesEvenementsZone As ICollection(Of SelectListItem)

    <Display(Name:="NombreDePersonneEvacue", ResourceType:=GetType(Resource))>
    Public Property NombreDePersonneEvacue As Long?

    <Display(Name:="NombreDePersonneAffecter", ResourceType:=GetType(Resource))>
    Public Property NombreDePersonneAffecter As Long?

    <Display(Name:="NombreDePersonneDirrectementAffecter", ResourceType:=GetType(Resource))>
    Public Property NombreDePersonneDirrectementAffecter As Long?

    <Display(Name:="NombreDePersonneRelocaliser", ResourceType:=GetType(Resource))>
    Public Property NombreDePersonneRelocaliser As Long?

    <Display(Name:="TotalPerteEconomiqueLocalDevise", ResourceType:=GetType(Resource))>
    Public Property TotalPerteEconomiqueLocalDevise As Double?

    <Display(Name:="TotalPerteEconomiqueDolar", ResourceType:=GetType(Resource))>
    Public Property TotalPerteEconomiqueDolar As Double?

    <Display(Name:="AutrePerte", ResourceType:=GetType(Resource))>
    Public Property AutrePerte As String

    <Display(Name:="AmpleurDuDanger", ResourceType:=GetType(Resource))>
    Public Property AmpleurDuDanger As String

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

    Public Sub New(entity As AutreImpactHumainEtEconomique)
        With Me
            .Id = entity.Id
            .EvenementZoneId = entity.EvenementZoneId
            .EvenementZone = entity.EvenementZone
            .NombreDePersonneEvacue = entity.NombreDePersonneEvacue
            .NombreDePersonneAffecter = entity.NombreDePersonneAffecter
            .NombreDePersonneDirrectementAffecter = entity.NombreDePersonneDirrectementAffecter
            .NombreDePersonneRelocaliser = entity.NombreDePersonneRelocaliser
            .TotalPerteEconomiqueLocalDevise = entity.TotalPerteEconomiqueLocalDevise
            .TotalPerteEconomiqueDolar = entity.TotalPerteEconomiqueDolar
            .AutrePerte = entity.AutrePerte
            .AmpleurDuDanger = entity.AmpleurDuDanger
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As AutreImpactHumainEtEconomique
        Dim entity As New AutreImpactHumainEtEconomique
        With entity
            .Id = Id
            .EvenementZoneId = EvenementZoneId
            .NombreDePersonneEvacue = NombreDePersonneEvacue
            .NombreDePersonneAffecter = NombreDePersonneAffecter
            .NombreDePersonneDirrectementAffecter = NombreDePersonneDirrectementAffecter
            .NombreDePersonneRelocaliser = NombreDePersonneRelocaliser
            .TotalPerteEconomiqueLocalDevise = TotalPerteEconomiqueLocalDevise
            .TotalPerteEconomiqueDolar = TotalPerteEconomiqueDolar
            .AutrePerte = AutrePerte
            .AmpleurDuDanger = AmpleurDuDanger
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function

End Class
