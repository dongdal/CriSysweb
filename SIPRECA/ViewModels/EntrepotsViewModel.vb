Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Spatial
Imports SIPRECA.My.Resources

Public Class EntrepotsViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Nom", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Nom As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Code", ResourceType:=GetType(Resource))>
    <StringLength(5, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Code As String

    <StringLength(30, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    <Display(Name:="CodePostale", ResourceType:=GetType(Resource))>
    Public Property CodePostale As String

    <Display(Name:="Capacite", ResourceType:=GetType(Resource))>
    Public Property Capacite As Double

    <Display(Name:="CapaciteDisponible", ResourceType:=GetType(Resource))>
    Public Property CapaciteDisponible As Double

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Telephone", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Telephone As String

    <Display(Name:="Telephone2", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Telephone2 As String

    <Display(Name:="Email", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Email As String

    <Display(Name:="Location", ResourceType:=GetType(Resource))>
    Public Property Location As DbGeometry

    <RegularExpression("^(\d+(((\,))\d+)?)$", ErrorMessageResourceName:="DecimalDataType", ErrorMessageResourceType:=GetType(Resource))>
    <Display(Name:="Latitude", ResourceType:=GetType(Resource))>
    Public Property GeoLatitude As Double?

    <RegularExpression("^(\d+(((\,))\d+)?)$", ErrorMessageResourceName:="DecimalDataType", ErrorMessageResourceType:=GetType(Resource))>
    <Display(Name:="GeoLongitude", ResourceType:=GetType(Resource))>
    Public Property GeoLongitude As Double?

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
    <Display(Name:="TypeEntrepot", ResourceType:=GetType(Resource))>
    Public Property TypeEntrepotId As Long
    Public Overridable Property LesTypeEntrepots As ICollection(Of SelectListItem)
    Public Overridable Property TypeEntrepot As TypeEntrepot

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

    <Display(Name:="Materiel", ResourceType:=GetType(Resource))>
    Public Property MaterielEntrepotId As Long?
    Public Overridable Property LesMaterielEntrepots As ICollection(Of SelectListItem)
    Public Overridable Property MaterielEntrepots As ICollection(Of MaterielEntrepots)

    <Display(Name:="Quantite", ResourceType:=GetType(Resource))>
    Public Property Quantite As Long?

    Public Sub New()
    End Sub

    Public Sub New(entity As Entrepots)
        With Me
            .Id = entity.Id
            .Nom = entity.Nom
            .Code = entity.Code
            .CodePostale = entity.CodePostale
            .Telephone = entity.Telephone
            .Email = entity.Email
            .CommuneId = entity.CommuneId
            .Commune = entity.Commune
            .Capacite = entity.Capacite
            .CapaciteDisponible = entity.CapaciteDisponible
            .Location = entity.Location
            .Telephone2 = entity.Telephone2
            .TypeEntrepotId = entity.TypeEntrepotId
            .TypeEntrepot = entity.TypeEntrepot
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

    Public Function GetEntity() As Entrepots
        Dim entity As New Entrepots
        With entity
            .Id = Id
            .Nom = Nom
            .Code = Code
            .Telephone = Telephone
            .Telephone2 = Telephone2
            .CommuneId = CommuneId
            .Capacite = Capacite
            .CapaciteDisponible = CapaciteDisponible
            .Location = Location
            .Email = Email
            .TypeEntrepotId = TypeEntrepotId
            .CodePostale = CodePostale
            .OganisationId = OrganisationId
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function

End Class

