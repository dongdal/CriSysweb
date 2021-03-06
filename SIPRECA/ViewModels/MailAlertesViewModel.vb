Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class MailAlertesViewModel
    Public Property Id As Long = 0

    <AllowHtml>
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Contenu", ResourceType:=GetType(Resource))>
    <StringLength(4000, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Contenu As String

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

    <Display(Name:="TypeSinistre", ResourceType:=GetType(Resource))>
    Public Property TypeSinistreId As Long
    Public Overridable Property LesTypeSinistre As ICollection(Of SelectListItem)
    Public Overridable Property TypeSinistre As TypeSinistre

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="SinistreConcernes", ResourceType:=GetType(Resource))>
    Public Property SinistreId As Long
    Public Overridable Property LesSinistres As ICollection(Of SelectListItem)
    Public Overridable Property Sinistre As Sinistre

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="CommuneConcernees", ResourceType:=GetType(Resource))>
    Public Property CommuneId As List(Of Long)
    Public Overridable Property LesCommunes As ICollection(Of SelectListItem)
    Public Overridable Property Commune As Commune

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Organisation", ResourceType:=GetType(Resource))>
    Public Property OrganisationId As Long
    Public Overridable Property LesOrganisations As ICollection(Of SelectListItem)
    Public Overridable Property Organisation As Organisation


    Public Sub New()
    End Sub

    Public Sub New(entity As Alert)
        With Me
            .Id = entity.Id
            .OrganisationId = entity.OrganisationId
            .SinistreId = entity.SinistreId
            .Sinistre = entity.Sinistre
            .Organisation = entity.Organisation
            .Contenu = entity.Contenu
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub
    'Public Sub New(entity As Abris)
    '    With Me
    '        .Id = entity.Id
    '        .Nom = entity.Nom
    '        .EstimationPopulation = entity.EstimationPopulation
    '        .Capacite = entity.Capacite
    '        .VilleId = entity.VilleId
    '        .Ville = entity.Ville
    '        .Location = entity.Location
    '        .TypeAbrisId = entity.TypeAbrisId
    '        .TypeAbris = entity.TypeAbris
    '        .OrganisationId = entity.OganisationId
    '        .Organisation = entity.Oganisation
    '        .StatutExistant = entity.StatutExistant
    '        .DateCreation = entity.DateCreation
    '        .AspNetUser = entity.AspNetUser
    '        .AspNetUserId = entity.AspNetUserId
    '    End With
    'End Sub

    'Public Function GetEntity() As Abris
    '    Dim entity As New Abris
    '    With entity
    '        .Id = Id
    '        .Nom = Nom
    '        .EstimationPopulation = EstimationPopulation
    '        .Capacite = Capacite
    '        .VilleId = VilleId
    '        .Location = Location
    '        .TypeAbrisId = TypeAbrisId
    '        .OganisationId = OrganisationId
    '        .StatutExistant = StatutExistant
    '        .DateCreation = DateCreation
    '        .AspNetUserId = AspNetUserId
    '    End With
    '    Return entity
    'End Function

End Class

