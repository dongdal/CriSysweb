Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class RisqueZoneViewModel
    Public Property Id As Long

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

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Risque", ResourceType:=GetType(Resource))>
    Public Property RisqueId As String
    Public Overridable Property LesRisques As ICollection(Of SelectListItem)
    Public Overridable Property Risque As Risque

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="ZoneARisque", ResourceType:=GetType(Resource))>
    Public Property ZoneARisqueId As String
    Public Overridable Property LesZoneARisques As ICollection(Of SelectListItem)
    Public Overridable Property ZoneARisque As ZoneARisque

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="NiveauDAlert", ResourceType:=GetType(Resource))>
    Public Property NiveauDAlertId As String
    Public Overridable Property LesNiveauDAlerts As ICollection(Of SelectListItem)
    Public Overridable Property NiveauDAlert As NiveauDAlert

    Public Sub New()
    End Sub

    Public Sub New(entity As RisqueZone)
        With Me
            .Id = entity.Id
            .NiveauDAlert = entity.NiveauDAlert
            .NiveauDAlertId = entity.NiveauDAlertId
            .ZoneARisqueId = entity.ZoneARisqueId
            .ZoneARisque = entity.ZoneARisque
            .Risque = entity.Risque
            .RisqueId = entity.RisqueId
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As RisqueZone
        Dim entity As New RisqueZone
        With entity
            .Id = Id
            .NiveauDAlertId = NiveauDAlertId
            .ZoneARisqueId = ZoneARisqueId
            .RisqueId = RisqueId
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class

