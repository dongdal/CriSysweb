Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class ActionSousRessourceViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Actions", ResourceType:=GetType(Resource))>
    Public Property ActionsId As Long
    Public Overridable Property LesActions As ICollection(Of SelectListItem)
    Public Overridable Property Actions As Actions

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="SousRessource", ResourceType:=GetType(Resource))>
    Public Property SousRessourceId As Long
    Public Overridable Property LesSousRessources As ICollection(Of SelectListItem)
    Public Overridable Property SousRessource As SousRessource

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

    Public Sub New()
    End Sub

    Public Sub New(entity As ActionSousRessource)
        With Me
            .Id = entity.Id
            .ActionsId = entity.ActionsId
            .Actions = entity.Actions
            .SousRessourceId = entity.SousRessourceId
            .SousRessource = entity.SousRessource
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As ActionSousRessource
        Dim entity As New ActionSousRessource
        With entity
            .Id = Id
            .ActionsId = ActionsId
            .SousRessourceId = SousRessourceId
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class

