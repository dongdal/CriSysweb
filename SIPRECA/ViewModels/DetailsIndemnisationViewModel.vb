Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class DetailsIndemnisationViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="NatureAide", ResourceType:=GetType(Resource))>
    Public Property NatureAideId As String
    Public Overridable Property LesNatureAide As ICollection(Of SelectListItem)
    Public Overridable Property NatureAide As NatureAide

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="LesIndemnisations", ResourceType:=GetType(Resource))>
    Public Property IndemnisationId As String
    Public Overridable Property LesIndemnisations As ICollection(Of SelectListItem)
    Public Overridable Property Indemnisation As Indemnisation

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateCreation", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateCreation As DateTime = Now

    <Display(Name:="Utilisateur", ResourceType:=GetType(Resource))>
    Public Property AspNetUserId As String
    Public Overridable Property LesUtilisateurs As ICollection(Of SelectListItem)
    Public Overridable Property AspNetUser As ApplicationUser

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Quantite", ResourceType:=GetType(Resource))>
    Public Property Quantite As Double

    <Display(Name:="StatutExistant", ResourceType:=GetType(Resource))>
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    Public Property StatutExistant As Short = 1

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Description", ResourceType:=GetType(Resource))>
    <StringLength(4000, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Description As String

    Public Sub New()
    End Sub

    Public Sub New(entity As DetailsIndemnisation)
        With Me
            .Id = entity.Id
            .Indemnisation = entity.Indemnisation
            .IndemnisationId = entity.IndemnisationId
            .NatureAide = entity.NatureAide
            .NatureAideId = entity.NatureAideId
            .Description = entity.Description
            .Quantite = entity.Quantite
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As DetailsIndemnisation
        Dim entity As New DetailsIndemnisation
        With entity
            .Id = Id
            .IndemnisationId = IndemnisationId
            .NatureAide = NatureAide
            .NatureAideId = NatureAideId
            .Description = Description
            .Quantite = Quantite
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class

