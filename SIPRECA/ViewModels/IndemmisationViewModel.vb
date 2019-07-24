Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class IndemmisationViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Montant", ResourceType:=GetType(Resource))>
    Public Property Montant As Double

    <Display(Name:="Demande", ResourceType:=GetType(Resource))>
    Public Property DemandetId As String
    Public Overridable Property Demandes As ICollection(Of SelectListItem)
    Public Overridable Property Demande As Demande

    <Display(Name:="StatutExistant", ResourceType:=GetType(Resource))>
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    Public Property StatutExistant As Short = 1

    <Display(Name:="Collectivite", ResourceType:=GetType(Resource))>
    Public Property CollectiviteId As String
    Public Overridable Property Collectivies As ICollection(Of SelectListItem)
    Public Overridable Property Collectivite As Collectivite

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateCreation", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateCreation As DateTime = Now

    <Display(Name:="Utilisateur", ResourceType:=GetType(Resource))>
    Public Property AspNetUserId As String
    Public Overridable Property LesUtilisateurs As ICollection(Of SelectListItem)
    Public Overridable Property AspNetUser As ApplicationUser

    Public Sub New()
    End Sub

    Public Sub New(entity As Indemmisation)
        With Me
            .Id = entity.Id
            .Collectivite = entity.Collectivite
            .CollectiviteId = entity.CollectiviteId
            .Demande = entity.Demande
            .DemandetId = entity.DemandeId
            .Montant = entity.Montant
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As Indemmisation
        Dim entity As New Indemmisation
        With entity
            .Id = Id
            .Collectivite = Collectivite
            .CollectiviteId = CollectiviteId
            .Demande = Demande
            .DemandeId = DemandetId
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class

