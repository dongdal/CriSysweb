Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class SuiviViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Libelle", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Libelle As String

    <Display(Name:="Demande", ResourceType:=GetType(Resource))>
    Public Property DemandeId As String
    Public Overridable Property Demandes As ICollection(Of SelectListItem)
    Public Overridable Property Demande As Demande

    <Display(Name:="StatutExistant", ResourceType:=GetType(Resource))>
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    Public Property StatutExistant As Short = 1

    <Display(Name:="TypeSuivi", ResourceType:=GetType(Resource))>
    Public Property TypeSuiviId As String
    Public Overridable Property TypeSuivis As ICollection(Of SelectListItem)
    Public Overridable Property TypeSuivi As TypeSuivi

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

    Public Sub New(entity As Suivi)
        With Me
            .Id = entity.Id
            .Demande = entity.Demande
            .DemandeId = entity.DemandeId
            .TypeSuivi = entity.TypeSuivi
            .TypeSuiviId = entity.TypeSuiviId
            .Libelle = entity.Libelle
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As Suivi
        Dim entity As New Suivi
        With entity
            .Id = Id
            .Demande = Demande
            .DemandeId = DemandeId
            .TypeSuivi = TypeSuivi
            .TypeSuiviId = TypeSuiviId
            .Libelle = Libelle
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class

