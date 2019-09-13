Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class ProjetViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Reference", ResourceType:=GetType(Resource))>
    <StringLength(20, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Reference As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Nom", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Nom As String

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Description", ResourceType:=GetType(Resource))>
    <StringLength(2000, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Description As String

    <Display(Name:="Budget", ResourceType:=GetType(Resource))>
    Public Property Budget As Double

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateDebut", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateDebut As Date

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateFin", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateFin As Date

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

    <Display(Name:="Devise", ResourceType:=GetType(Resource))>
    Public Property DeviseId As Long
    Public Overridable Property LesDevises As ICollection(Of SelectListItem)
    Public Overridable Property Devise As Devise

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Organisation", ResourceType:=GetType(Resource))>
    Public Property OrganisationId As Long
    Public Overridable Property LesOrganisations As ICollection(Of SelectListItem)
    Public Overridable Property Organisation As Organisation

    <Display(Name:="PersonnelProjet", ResourceType:=GetType(Resource))>
    Public Property PersonnelProjetId As Long?
    Public Overridable Property LesPersonnelProjets As ICollection(Of SelectListItem)
    Public Overridable Property PersonnelProjets As ICollection(Of Personnel)

    Public Sub New()
    End Sub

    Public Sub New(entity As Projet)
        With Me
            .Id = entity.Id
            .Reference = entity.Reference
            .Nom = entity.Nom
            .Description = entity.Description
            .Budget = entity.Budget
            .DateDebut = entity.DateDebut
            .DateFin = entity.DateFin
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
            .Organisation = entity.Oganisation
            .OrganisationId = entity.OganisationId
            .DeviseId = entity.DeviseId
            .Devise = entity.Devise
        End With
    End Sub

    Public Function GetEntity() As Projet
        Dim entity As New Projet
        With entity
            .Id = Id
            .Reference = Reference
            .Nom = Nom
            .Description = Description
            .Budget = Budget
            .DateDebut = DateDebut
            .DateFin = DateFin
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
            .OganisationId = OrganisationId
            .DeviseId = DeviseId
        End With
        Return entity
    End Function


End Class

