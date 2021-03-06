Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Spatial
Imports SIPRECA.My.Resources

Public Class HopitauxViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Nom", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Nom As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Code", ResourceType:=GetType(Resource))>
    <StringLength(5, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Code As String

    <Display(Name:="NombreDeLitMin", ResourceType:=GetType(Resource))>
    Public Property NombreDeLitMin As Long

    <Display(Name:="NombreDeLitMax", ResourceType:=GetType(Resource))>
    Public Property NombreDeLitMax As Long

    <Display(Name:="NombreDeMedecin", ResourceType:=GetType(Resource))>
    Public Property NombreDeMedecin As Long

    <Display(Name:="NombreDInfimiere", ResourceType:=GetType(Resource))>
    Public Property NombreDInfimiere As Long

    <Display(Name:="NombreDePersonnelNonMedical", ResourceType:=GetType(Resource))>
    Public Property NombreDePersonnelNonMedical As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <RegularExpression("^\d{9}$", ErrorMessageResourceName:="PhoneNumberType", ErrorMessageResourceType:=GetType(Resource))>
    <Display(Name:="Telephone", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Telephone As String

    <Display(Name:="TelephoneUrgence", ResourceType:=GetType(Resource))>
    <RegularExpression("^\d{9}$", ErrorMessageResourceName:="PhoneNumberType", ErrorMessageResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property TelephoneUrgence As String

    <Display(Name:="Email", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Email As String

    <Display(Name:="SiteWeb", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property SiteWeb As String

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
    <Display(Name:="TypeHopitaux", ResourceType:=GetType(Resource))>
    Public Property TypeHopitauxId As Long
    Public Overridable Property LesTypeHopitauxs As ICollection(Of SelectListItem)
    Public Overridable Property TypeHopitaux As TypeHopitaux

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

    <Display(Name:="HopitauxPuissance", ResourceType:=GetType(Resource))>
    Public Property HopitauxPuissanceId As Long?
    Public Overridable Property LesHopitauxPuissances As ICollection(Of SelectListItem)
    Public Overridable Property HopitauxPuissances As ICollection(Of HopitauxPuissance)

    <Display(Name:="Materiel", ResourceType:=GetType(Resource))>
    Public Property MaterielHopitauxId As Long?
    Public Overridable Property LesMaterielHopitaux As ICollection(Of SelectListItem)
    Public Overridable Property MaterielHopitaux As ICollection(Of MaterielHopitaux)

    <Display(Name:="Quantite", ResourceType:=GetType(Resource))>
    Public Property Quantite As Long?

    Public Sub New()
    End Sub

    Public Sub New(entity As Hopitaux)
        With Me
            .Id = entity.Id
            .Nom = entity.Nom
            .Code = entity.Code
            .NombreDeLitMax = entity.NombreDeLitMax
            .NombreDeLitMin = entity.NombreDeLitMin
            .NombreDeMedecin = entity.NombreDeMedecin
            .NombreDInfimiere = entity.NombreDInfimiere
            .NombreDePersonnelNonMedical = entity.NombreDePersonnelNonMedical
            .SiteWeb = entity.SiteWeb
            .Telephone = entity.Telephone
            .Email = entity.Email
            .CommuneId = entity.CommuneId
            .Commune = entity.Commune
            .Location = entity.Location
            .TelephoneUrgence = entity.TelephoneUrgence
            .TypeHopitauxId = entity.TypeHopitauxId
            .TypeHopitaux = entity.TypeHopitaux
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

    Public Function GetEntity() As Hopitaux
        Dim entity As New Hopitaux
        With entity
            .Id = Id
            .Nom = Nom
            .Code = Code
            .NombreDeLitMax = NombreDeLitMax
            .NombreDeLitMin = NombreDeLitMin
            .NombreDeMedecin = NombreDeMedecin
            .NombreDInfimiere = NombreDInfimiere
            .NombreDePersonnelNonMedical = NombreDePersonnelNonMedical
            .SiteWeb = SiteWeb
            .Telephone = Telephone
            .TelephoneUrgence = TelephoneUrgence
            .CommuneId = CommuneId
            .Location = Location
            .Email = Email
            .TypeHopitauxId = TypeHopitauxId
            .TypeHopitaux = TypeHopitaux
            .OganisationId = OrganisationId
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function

End Class

