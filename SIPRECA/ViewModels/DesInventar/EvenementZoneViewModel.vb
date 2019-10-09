Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class EvenementZoneViewModel
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
    <Display(Name:="Evenement", ResourceType:=GetType(Resource))>
    Public Property EvenementId As Long
    Public Overridable Property LesEvenements As ICollection(Of SelectListItem)
    Public Overridable Property Evenement As Evenement

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="ZoneARisque", ResourceType:=GetType(Resource))>
    Public Property ZoneARisqueId As Long
    Public Overridable Property LesZoneARisques As ICollection(Of SelectListItem)
    Public Overridable Property ZoneARisque As ZoneARisque


    Public Sub New()
    End Sub

    Public Sub New(entity As EvenementZone)
        With Me
            .Id = entity.Id
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
            .ZoneARisque = entity.ZoneARisque
            .ZoneARisqueId = entity.ZoneARisqueId
            .EvenementId = entity.EvenementId
            .Evenement = entity.Evenement
        End With
    End Sub

    Public Function GetEntity() As EvenementZone
        Dim entity As New EvenementZone
        With entity
            .Id = Id
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
            .ZoneARisqueId = ZoneARisqueId
            .EvenementId = EvenementId
        End With
        Return entity
    End Function


End Class

