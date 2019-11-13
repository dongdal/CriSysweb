Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Spatial
Imports SIPRECA.My.Resources

Public Class ZoneARisqueViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Libelle", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Libelle As String

    <Display(Name:="Location", ResourceType:=GetType(Resource))>
    Public Property Location As DbGeometry

    <Display(Name:="StatutExistant", ResourceType:=GetType(Resource))>
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    Public Property StatutExistant As Short = 1

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateCreation", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateCreation As DateTime = Now

    <Display(Name:="Utilisateur", ResourceType:=GetType(Resource))>
    Public Property AspNetUserId As String
    Public Overridable Property LesUtilisateurs As ICollection(Of SelectListItem)
    Public Overridable Property AspNetUser As ApplicationUser

    <Display(Name:="Quartier", ResourceType:=GetType(Resource))>
    Public Property QuartierId As Long?
    Public Overridable Property LesQuartiers As ICollection(Of SelectListItem)
    Public Overridable Property ZoneLocalisations As ICollection(Of ZoneLocalisation)


    <Display(Name:="Risque", ResourceType:=GetType(Resource))>
    Public Property RisqueId As Long?
    Public Overridable Property LesRisques As ICollection(Of SelectListItem)


    <Display(Name:="NiveauDAlert", ResourceType:=GetType(Resource))>
    Public Property NiveauDAlertId As Long?
    Public Overridable Property LesNiveauDAlerts As ICollection(Of SelectListItem)
    Public Overridable Property RisqueZones As ICollection(Of RisqueZone)

    Public Sub New()
    End Sub

    Public Sub New(entity As ZoneARisque)
        With Me
            .Id = entity.Id
            .Libelle = entity.Libelle
            .Location = entity.Location
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As ZoneARisque
        Dim entity As New ZoneARisque
        With entity
            .Id = Id
            .Libelle = Libelle
            .Location = Location
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class

