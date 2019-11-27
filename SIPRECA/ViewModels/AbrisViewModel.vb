Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Spatial
Imports SIPRECA.My.Resources

Public Class AbrisViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Nom", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Nom As String

    <Display(Name:="EstimationPopulation", ResourceType:=GetType(Resource))>
    Public Property EstimationPopulation As Long

    <Display(Name:="Capacite", ResourceType:=GetType(Resource))>
    Public Property Capacite As Long

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Location", ResourceType:=GetType(Resource))>
    Public Property Location As DbGeometry

    <RegularExpression("^(\d+(((\,))\d+)?)$", ErrorMessageResourceName:="DecimalDataType", ErrorMessageResourceType:=GetType(Resource))>
    <Display(Name:="Latitude", ResourceType:=GetType(Resource))>
    Public Property GeoLatitude As Double? = 0.0

    <RegularExpression("^(\d+(((\,))\d+)?)$", ErrorMessageResourceName:="DecimalDataType", ErrorMessageResourceType:=GetType(Resource))>
    <Display(Name:="GeoLongitude", ResourceType:=GetType(Resource))>
    Public Property GeoLongitude As Double? = 0.0

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
    <Display(Name:="TypeAbris", ResourceType:=GetType(Resource))>
    Public Property TypeAbrisId As Long
    Public Overridable Property LesTypeAbris As ICollection(Of SelectListItem)
    Public Overridable Property TypeAbris As TypeAbris

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Commune", ResourceType:=GetType(Resource))>
    Public Property CommuneId As Long
    Public Overridable Property LesCommunes As ICollection(Of SelectListItem)
    Public Overridable Property Commune As Commune

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Organisation", ResourceType:=GetType(Resource))>
    Public Property OrganisationId As Long
    Public Overridable Property LesOrganisations As ICollection(Of SelectListItem)
    Public Overridable Property Organisation As Organisation

    <Display(Name:="TitreDuPoste", ResourceType:=GetType(Resource))>
    <StringLength(80, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property TitreDuPoste As String

    <Display(Name:="Materiel", ResourceType:=GetType(Resource))>
    Public Property MaterielAbrisId As Long?
    Public Overridable Property LesMaterielAbris As ICollection(Of SelectListItem)
    Public Overridable Property MaterielAbris As ICollection(Of MaterielAbris)

    <Display(Name:="Quantite", ResourceType:=GetType(Resource))>
    Public Property Quantite As Long?

    <Display(Name:="PersonnelAbris", ResourceType:=GetType(Resource))>
    Public Property PersonnelAbrisId As Long?
    Public Overridable Property LesPersonnelAbris As ICollection(Of SelectListItem)
    Public Overridable Property PersonnelAbris As ICollection(Of PersonnelAbris)

    Public Sub New()
    End Sub

    Public Sub New(entity As Abris)
        With Me
            .Id = entity.Id
            .Nom = entity.Nom
            .EstimationPopulation = entity.EstimationPopulation
            .Capacite = entity.Capacite
            .CommuneId = entity.CommuneId
            .Commune = entity.Commune
            .Location = entity.Location
            .TypeAbrisId = entity.TypeAbrisId
            .TypeAbris = entity.TypeAbris
            .OrganisationId = entity.OganisationId
            .Organisation = entity.Oganisation
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
            .GeoLongitude = entity.Location.XCoordinate.ToString()
            .GeoLatitude = entity.Location.YCoordinate.ToString()
        End With
    End Sub

    Public Function GetEntity() As Abris
        Dim entity As New Abris
        With entity
            .Id = Id
            .Nom = Nom
            .EstimationPopulation = EstimationPopulation
            .Capacite = Capacite
            .CommuneId = CommuneId
            .Location = Location
            .TypeAbrisId = TypeAbrisId
            .OganisationId = OrganisationId
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function

End Class

