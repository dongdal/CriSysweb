Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Spatial
Imports SIPRECA.My.Resources

Public Class AeroportViewModel

    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Nom", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Nom As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="ICAO", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property ICAO As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="IATA", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property IATA As String

    <Display(Name:="LongueurDePiste", ResourceType:=GetType(Resource))>
    Public Property LongueurDePiste As Double

    <Display(Name:="LargeurDePiste", ResourceType:=GetType(Resource))>
    Public Property LargeurDePiste As Double

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

    <Display(Name:="SiteWeb", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property SiteWeb As String

    <Display(Name:="Location", ResourceType:=GetType(Resource))>
    Public Property Location As DbGeometry


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
    <Display(Name:="UsageHumanitaire", ResourceType:=GetType(Resource))>
    Public Property UsageHumanitaireId As Long
    Public Overridable Property LesUsageHumanitaires As ICollection(Of SelectListItem)
    Public Overridable Property UsageHumanitaire As UsageHumanitaire

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="TailleDeAeronef", ResourceType:=GetType(Resource))>
    Public Property TailleDeAeronefId As Long
    Public Overridable Property LesTailleDeAeronefs As ICollection(Of SelectListItem)
    Public Overridable Property TailleDeAeronef As TailleDeAeronef

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="SurfaceDePiste", ResourceType:=GetType(Resource))>
    Public Property SurfaceDePisteId As Long
    Public Overridable Property LesSurfaceDePistes As ICollection(Of SelectListItem)
    Public Overridable Property SurfaceDePiste As SurfaceDePiste

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Commune", ResourceType:=GetType(Resource))>
    Public Property CommuneId As Long
    Public Overridable Property LesCommunes As ICollection(Of SelectListItem)
    Public Overridable Property Commune As Commune

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Organisation", ResourceType:=GetType(Resource))>
    Public Property OganisationId As Long
    Public Overridable Property LesOrganisations As ICollection(Of SelectListItem)
    Public Overridable Property Organisation As Organisation

    <Display(Name:="Materiel", ResourceType:=GetType(Resource))>
    Public Property MaterielAeroportId As Long?
    Public Overridable Property LesMaterielAeroport As ICollection(Of SelectListItem)
    Public Overridable Property MaterielAeroport As ICollection(Of MaterielAeroport)

    <Display(Name:="Quantite", ResourceType:=GetType(Resource))>
    Public Property Quantite As Long?

    Public Sub New()
    End Sub

    Public Sub New(entity As Aeroport)
        With Me
            .Id = entity.Id
            .Nom = entity.Nom
            .ICAO = entity.ICAO
            .IATA = entity.IATA
            .LongueurDePiste = entity.LongueurDePiste
            .LargeurDePiste = entity.LargeurDePiste
            .UsageHumanitaireId = entity.UsageHumanitaireId
            .UsageHumanitaire = entity.UsageHumanitaire
            .SiteWeb = entity.SiteWeb
            .Telephone = entity.Telephone
            .Email = entity.Email
            .CommuneId = entity.CommuneId
            .Commune = entity.Commune
            .Location = entity.Location
            .TailleDeAeronef = entity.TailleDeAeronef
            .TailleDeAeronefId = entity.TailleDeAeronefId
            .SurfaceDePiste = entity.SurfaceDePiste
            .SurfaceDePisteId = entity.SurfaceDePisteId
            .OganisationId = entity.OganisationId
            .Organisation = entity.Oganisation
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As Aeroport
        Dim entity As New Aeroport
        With entity
            .Id = Id
            .Nom = Nom
            .ICAO = ICAO
            .IATA = IATA
            .LongueurDePiste = LongueurDePiste
            .LargeurDePiste = LargeurDePiste
            .UsageHumanitaireId = UsageHumanitaireId
            .SiteWeb = SiteWeb
            .Telephone = Telephone
            .Email = Email
            .CommuneId = CommuneId
            .Location = Location
            .TailleDeAeronefId = TailleDeAeronefId
            .SurfaceDePisteId = SurfaceDePisteId
            .OganisationId = OganisationId
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function

End Class

