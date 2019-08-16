Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class IndemnisationViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Libelle", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Libelle As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Demande", ResourceType:=GetType(Resource))>
    Public Property DemandeId As String
    Public Overridable Property LesDemande As ICollection(Of SelectListItem)
    Public Overridable Property Demande As Demande

    <Display(Name:="NatureAide", ResourceType:=GetType(Resource))>
    Public Property NatureAideId As Long?
    Public Overridable Property LesNatureAides As ICollection(Of SelectListItem) ' LesNatureAides à donner
    Public Overridable Property NatureAide As ICollection(Of NatureAide) ' NatureAide déjà donné

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateCreation", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateCreation As DateTime = Now

    <Display(Name:="Utilisateur", ResourceType:=GetType(Resource))>
    Public Property AspNetUserId As String
    Public Overridable Property LesUtilisateurs As ICollection(Of SelectListItem)
    Public Overridable Property AspNetUser As ApplicationUser

    <Display(Name:="StatutExistant", ResourceType:=GetType(Resource))>
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    Public Property StatutExistant As Short = 1

    <Display(Name:="Description", ResourceType:=GetType(Resource))>
    <StringLength(4000, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Description As String

    <Display(Name:="Quantite", ResourceType:=GetType(Resource))>
    Public Property Quantite As String = "0.0"

    Public Property DetailsIndemnisationId As Long?
    Public Overridable Property LesDetailsIndemnisations As ICollection(Of SelectListItem)
    Public Overridable Property DetailsIndemnisation As ICollection(Of DetailsIndemnisation)

    Public Sub New()
    End Sub

    Public Sub New(entity As Indemnisation)
        With Me
            .Id = entity.Id
            .Demande = entity.Demande
            .DemandeId = entity.DemandeId
            .Description = entity.Description
            .Libelle = entity.Libelle
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As Indemnisation
        Dim entity As New Indemnisation
        With entity
            .Id = Id
            .Demande = Demande
            .DemandeId = DemandeId
            .Description = Description
            .Libelle = Libelle
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class

