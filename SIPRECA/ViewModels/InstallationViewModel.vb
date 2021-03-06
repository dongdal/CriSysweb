Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Spatial
Imports SIPRECA.My.Resources

Public Class InstallationViewModel
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

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <RegularExpression("^\d{9}$", ErrorMessageResourceName:="PhoneNumberType", ErrorMessageResourceType:=GetType(Resource))>
    <Display(Name:="Telephone", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Telephone As String

    <Display(Name:="Telephone2", ResourceType:=GetType(Resource))>
    <RegularExpression("^\d{9}$", ErrorMessageResourceName:="PhoneNumberType", ErrorMessageResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Telephone2 As String

    <Display(Name:="Email", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Email As String

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

    <Display(Name:="HeureDOuverture", ResourceType:=GetType(Resource))>
    Public Property HeureDOuverture As TimeSpan

    <Display(Name:="HeureFermeture", ResourceType:=GetType(Resource))>
    Public Property HeureFermeture As TimeSpan

    <Display(Name:="Utilisateur", ResourceType:=GetType(Resource))>
    Public Property AspNetUserId As String
    Public Overridable Property LesUtilisateurs As ICollection(Of SelectListItem)
    Public Overridable Property AspNetUser As ApplicationUser

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

    <Display(Name:="PersonnelInstallation", ResourceType:=GetType(Resource))>
    Public Property PersonnelInstallationId As Long?
    Public Overridable Property LesPersonnelInstallations As ICollection(Of SelectListItem)
    Public Overridable Property PersonnelInstallations As ICollection(Of PersonnelInstallation)

    <Display(Name:="Materiel", ResourceType:=GetType(Resource))>
    Public Property MaterielInstallationId As Long?
    Public Overridable Property LesMaterielInstallations As ICollection(Of SelectListItem)
    Public Overridable Property MaterielInstallations As ICollection(Of MaterielInstallation)

    <Display(Name:="Quantite", ResourceType:=GetType(Resource))>
    Public Property Quantite As Long?

    Public Sub New()
    End Sub

    Public Sub New(entity As Installation)
        With Me
            .Id = entity.Id
            .Nom = entity.Nom
            .Code = entity.Code
            .CodePostale = entity.CodePostale
            .Telephone = entity.Telephone
            .HeureDOuverture = entity.HeureDOuverture
            .HeureFermeture = entity.HeureFermeture
            .Email = entity.Email
            .CommuneId = entity.CommuneId
            .Commune = entity.Commune
            .Location = entity.Location
            .Telephone2 = entity.Telephone2
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

    Public Function GetEntity() As Installation
        Dim entity As New Installation
        With entity
            .Id = Id
            .Nom = Nom
            .Code = Code
            .Telephone = Telephone
            .Telephone2 = Telephone2
            .HeureDOuverture = HeureDOuverture
            .HeureFermeture = HeureFermeture
            .CommuneId = CommuneId
            .Location = Location
            .Email = Email
            .CodePostale = CodePostale
            .OganisationId = OrganisationId
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function

End Class

