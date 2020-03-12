Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class OrganisationViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="TypeOrganisation", ResourceType:=GetType(Resource))>
    Public Property TypeOrganisationId As Long
    Public Overridable Property LesTypeOrganisations As ICollection(Of SelectListItem)
    Public Overridable Property TypeOrganisation As TypeOrganisation

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    '<Display(Name:="Secteur", ResourceType:=GetType(Resource))>
    'Public Property SecteurId As Long
    'Public Overridable Property LesSecteurs As ICollection(Of SelectListItem)
    'Public Overridable Property Secteur As Secteur

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Ville", ResourceType:=GetType(Resource))>
    Public Property VilleId As Long
    Public Overridable Property LesVilles As ICollection(Of SelectListItem)
    Public Overridable Property Ville As Ville

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Nom", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Nom As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Acronyme", ResourceType:=GetType(Resource))>
    <StringLength(20, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Acronyme As String

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="SiteWeb", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property SiteWeb As String

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <RegularExpression("^\d{9}$", ErrorMessageResourceName:="PhoneNumberType", ErrorMessageResourceType:=GetType(Resource))>
    <Display(Name:="Telephone", ResourceType:=GetType(Resource))>
    <StringLength(20, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Telephone As String

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Email", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Email As String

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="BoitePostale", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property BoitePostale As String

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

    Public Sub New()
    End Sub

    Public Sub New(entity As Organisation)
        With Me
            .Id = entity.Id
            .Acronyme = entity.Acronyme
            .Nom = entity.Nom
            .SiteWeb = entity.SiteWeb
            .Telephone = entity.Telephone
            .Email = entity.Email
            .BoitePostale = entity.BoitePostale
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
            .TypeOrganisationId = entity.TypeOrganisationId
            .TypeOrganisation = entity.TypeOrganisation
            .VilleId = entity.VilleId
            .Ville = entity.Ville
            '.Secteur = entity.Secteur
            '.SecteurId = entity.SecteurId
        End With
    End Sub

    Public Function GetEntity() As Organisation
        Dim entity As New Organisation
        With entity
            .Id = Id
            .Acronyme = Acronyme
            .Nom = Nom
            .SiteWeb = SiteWeb
            .Telephone = Telephone
            .Email = Email
            .BoitePostale = BoitePostale
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
            .TypeOrganisationId = TypeOrganisationId
            .VilleId = VilleId
            '.SecteurId = SecteurId
        End With
        Return entity
    End Function


End Class

