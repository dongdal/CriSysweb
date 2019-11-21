Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Spatial
Imports SIPRECA.My.Resources

Public Class PortDeMerViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Nom", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Nom As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Code", ResourceType:=GetType(Resource))>
    <StringLength(5, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Code As String

    <Display(Name:="ProfondeurQuaiChargementUnites", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property ProfondeurQuaiChargementUnites As String

    <Display(Name:="Possession", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Possession As String

    <Display(Name:="HauteurMaximumUnites", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property HauteurMaximumUnites As String


    <Display(Name:="HauteurMaximum", ResourceType:=GetType(Resource))>
    Public Property HauteurMaximum As Double

    <Display(Name:="ProfondeurQuaiChargement", ResourceType:=GetType(Resource))>
    Public Property ProfondeurQuaiChargement As Double

    <Display(Name:="ProfondeurTerminalPetrolier", ResourceType:=GetType(Resource))>
    Public Property ProfondeurTerminalPetrolier As Double

    <Display(Name:="ProfondeurTerminalPetrolierUnites", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property ProfondeurTerminalPetrolierUnites As String

    <Display(Name:="LongueurMaximaleNavire", ResourceType:=GetType(Resource))>
    Public Property LongueurMaximaleNavire As Double

    <Display(Name:="Reparations", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Reparations As String

    <Display(Name:="CaleSeche", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property CaleSeche As String

    <Display(Name:="Abri", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Abri As String

    <Display(Name:="LongueurMaximaleNavireUnites", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property LongueurMaximaleNavireUnites As String

    <Display(Name:="CapaciteStockageEntreposage", ResourceType:=GetType(Resource))>
    Public Property CapaciteStockageEntreposage As Double

    <Display(Name:="CapaciteStockageSecurise", ResourceType:=GetType(Resource))>
    Public Property CapaciteStockageSecurise As Double

    <Display(Name:="CapaciteStockageEntrepotDouanier", ResourceType:=GetType(Resource))>
    Public Property CapaciteStockageEntrepotDouanier As Double

    <Display(Name:="NombreRemorqueur", ResourceType:=GetType(Resource))>
    Public Property NombreRemorqueur As Long

    <Display(Name:="NombreBarge", ResourceType:=GetType(Resource))>
    Public Property NombreBarge As Double

    <Display(Name:="CapacietBarge", ResourceType:=GetType(Resource))>
    Public Property CapacietBarge As Double

    <Display(Name:="EquipementChargement", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property EquipementChargement As String

    <Display(Name:="CapaciteDouaniere", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property CapaciteDouaniere As String

    <Display(Name:="Securite", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Securite As String

    <Display(Name:="CapaciteRemorqueur", ResourceType:=GetType(Resource))>
    Public Property CapaciteRemorqueur As Double

    <Display(Name:="ProfondeurMareHaute", ResourceType:=GetType(Resource))>
    Public Property ProfondeurMareHaute As Double

    <Display(Name:="ProfondeurMareHauteUnites", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property ProfondeurMareHauteUnites As String

    <Display(Name:="ProfondeurMareBasse", ResourceType:=GetType(Resource))>
    Public Property ProfondeurMareBasse As Double

    <Display(Name:="ProfondeurMareBasseUnites", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property ProfondeurMareBasseUnites As String

    <Display(Name:="ProfondeurInondation", ResourceType:=GetType(Resource))>
    Public Property ProfondeurInondation As Double

    <Display(Name:="ProfondeurInondationUnites", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property ProfondeurInondationUnites As String

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
    Public Property MaterielPortDeMerId As Long?
    Public Overridable Property LesMaterielPortDeMers As ICollection(Of SelectListItem)
    Public Overridable Property MaterielPortDeMers As ICollection(Of MaterielPortDeMer)

    <Display(Name:="Quantite", ResourceType:=GetType(Resource))>
    Public Property Quantite As Long?

    Public Sub New()
    End Sub

    Public Sub New(entity As PortDeMer)
        With Me
            .Id = entity.Id
            .Nom = entity.Nom
            .Code = entity.Code
            .Possession = entity.Possession
            .HauteurMaximum = entity.HauteurMaximum
            .HauteurMaximumUnites = entity.HauteurMaximumUnites
            .ProfondeurQuaiChargement = entity.ProfondeurQuaiChargement
            .ProfondeurQuaiChargementUnites = entity.ProfondeurQuaiChargementUnites
            .ProfondeurTerminalPetrolier = entity.ProfondeurTerminalPetrolier
            .ProfondeurTerminalPetrolierUnites = entity.ProfondeurTerminalPetrolierUnites
            .CaleSeche = entity.CaleSeche
            .LongueurMaximaleNavire = entity.LongueurMaximaleNavire
            .LongueurMaximaleNavireUnites = entity.LongueurMaximaleNavireUnites
            .Reparations = entity.Reparations
            .Abri = entity.Abri
            .CapaciteStockageEntreposage = entity.CapaciteStockageEntreposage
            .CapaciteStockageSecurise = entity.CapaciteStockageSecurise
            .CapaciteStockageEntrepotDouanier = entity.CapaciteStockageEntrepotDouanier
            .NombreRemorqueur = entity.NombreRemorqueur
            .CapaciteRemorqueur = entity.CapaciteRemorqueur
            .NombreBarge = entity.NombreBarge
            .CapacietBarge = entity.CapacietBarge
            .EquipementChargement = entity.EquipementChargement
            .CapaciteDouaniere = entity.CapaciteDouaniere
            .Securite = entity.Securite
            .ProfondeurMareHaute = entity.ProfondeurMareHaute
            .ProfondeurMareHauteUnites = entity.ProfondeurMareHauteUnites
            .ProfondeurMareBasse = entity.ProfondeurMareBasse
            .ProfondeurMareBasseUnites = entity.ProfondeurMareBasseUnites
            .ProfondeurInondation = entity.ProfondeurInondation
            .ProfondeurInondationUnites = entity.ProfondeurInondationUnites
            .Telephone = entity.Telephone
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
        End With
    End Sub

    Public Function GetEntity() As PortDeMer
        Dim entity As New PortDeMer
        With entity
            .Id = Id
            .Nom = Nom
            .Code = Code
            .Possession = Possession
            .HauteurMaximum = HauteurMaximum
            .HauteurMaximumUnites = HauteurMaximumUnites
            .ProfondeurQuaiChargement = ProfondeurQuaiChargement
            .ProfondeurQuaiChargementUnites = ProfondeurQuaiChargementUnites
            .ProfondeurTerminalPetrolier = ProfondeurTerminalPetrolier
            .ProfondeurTerminalPetrolierUnites = ProfondeurTerminalPetrolierUnites
            .CaleSeche = CaleSeche
            .LongueurMaximaleNavire = LongueurMaximaleNavire
            .LongueurMaximaleNavireUnites = LongueurMaximaleNavireUnites
            .Reparations = Reparations
            .Abri = Abri
            .CapaciteStockageEntreposage = CapaciteStockageEntreposage
            .CapaciteStockageSecurise = CapaciteStockageSecurise
            .CapaciteStockageEntrepotDouanier = CapaciteStockageEntrepotDouanier
            .NombreRemorqueur = NombreRemorqueur
            .CapaciteRemorqueur = CapaciteRemorqueur
            .NombreBarge = NombreBarge
            .CapacietBarge = CapacietBarge
            .EquipementChargement = EquipementChargement
            .CapaciteDouaniere = CapaciteDouaniere
            .Securite = Securite
            .ProfondeurMareHaute = ProfondeurMareHaute
            .ProfondeurMareHauteUnites = ProfondeurMareHauteUnites
            .ProfondeurMareBasse = ProfondeurMareBasse
            .ProfondeurMareBasseUnites = ProfondeurMareBasseUnites
            .ProfondeurInondation = ProfondeurInondation
            .ProfondeurInondationUnites = ProfondeurInondationUnites
            .SiteWeb = SiteWeb
            .Telephone = Telephone
            .Telephone2 = Telephone2
            .CommuneId = CommuneId
            .Location = Location
            .Email = Email
            .OganisationId = OrganisationId
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function

End Class

