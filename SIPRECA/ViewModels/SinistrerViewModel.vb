Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class SinistrerViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="CNI", ResourceType:=GetType(Resource))>
    <StringLength(20, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Cni As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Nom", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Nom As String

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Prenom", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Prenom As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Telephone", ResourceType:=GetType(Resource))>
    <RegularExpression("^\d{9}$", ErrorMessageResourceName:="PhoneNumberType", ErrorMessageResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Telephone As String

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Email", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Email As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Sexe", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Sexe As String

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateDeNaissance", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateDeNaissance As DateTime = Now

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

    '-------------------------------------demande--------------------------------------------------------------------

    <Display(Name:="Observation", ResourceType:=GetType(Resource))>
    <StringLength(1000, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Observation As String

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DemandeCollectiviteSinistree", ResourceType:=GetType(Resource))>
    Public Property CollectiviteSinistreeId As Long = 0
    Public Overridable Property LesCollectiviteSinistrees As ICollection(Of SelectListItem)
    Public Overridable Property CollectiviteSinistree As CollectiviteSinistree

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="AnneeBudgetaire", ResourceType:=GetType(Resource))>
    Public Property AnneeBudgetaireId As Long
    Public Overridable Property LesAnneeBudgetaires As ICollection(Of SelectListItem)
    Public Overridable Property AnneeBudgetaire As AnneeBudgetaire

    <Display(Name:="DateDeclaration", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateDeclaration As Date = Now

    Public Sub New()
    End Sub

    Public Sub New(entity As Sinistrer)
        With Me
            .Id = entity.Id
            .Cni = entity.Cni
            .Nom = entity.Nom
            .Prenom = entity.Prenom
            .Telephone = entity.Telephone
            .Email = entity.Email
            .Sexe = entity.Sexe
            .DateDeNaissance = entity.DateDeNaissance
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As Sinistrer
        Dim entity As New Sinistrer
        With entity
            .Id = Id
            .Cni = Cni
            .Nom = Nom
            .Prenom = Prenom
            .Telephone = Telephone
            .Email = Email
            .Sexe = Sexe
            .DateDeNaissance = DateDeNaissance
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class

