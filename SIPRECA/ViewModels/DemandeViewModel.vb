Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class DemandeViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Reference", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Reference As String = "(.Auto)"

    <Display(Name:="Observation", ResourceType:=GetType(Resource))>
    <StringLength(1000, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Observation As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DemandeCollectiviteSinistree", ResourceType:=GetType(Resource))>
    Public Property CollectiviteSinistreeId As String
    Public Overridable Property LesCollectiviteSinistrees As ICollection(Of SelectListItem)
    Public Overridable Property CollectiviteSinistree As CollectiviteSinistree

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="AnneeBudgetaire", ResourceType:=GetType(Resource))>
    Public Property AnneeBudgetaireId As Long
    Public Overridable Property LesAnneeBudgetaires As ICollection(Of SelectListItem)
    Public Overridable Property AnneeBudgetaire As AnneeBudgetaire

    <Display(Name:="StatutExistant", ResourceType:=GetType(Resource))>
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    Public Property StatutExistant As Short = Util.ElementsSuiviDemandes.CreationCommunal

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="LeSinistrer", ResourceType:=GetType(Resource))>
    Public Property SinistrerId As String
    Public Overridable Property LesSinistrers As ICollection(Of SelectListItem)
    Public Overridable Property Sinistrer As Sinistrer

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateCreation", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateCreation As DateTime = Now

    <Display(Name:="DateDeclaration", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateDeclaration As Date = Now


    <Display(Name:="Utilisateur", ResourceType:=GetType(Resource))>
    Public Property AspNetUserId As String
    Public Overridable Property LesUtilisateurs As ICollection(Of SelectListItem)
    Public Overridable Property AspNetUser As ApplicationUser

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="SelectFile")>
    <Display(Name:="PieceJointe", ResourceType:=GetType(Resource))>
    Public Property Fichiers As New List(Of HttpPostedFileBase)
    'Public Property Fichiers As HttpPostedFileBase = Nothing

    <Display(Name:="PiecesJointeMenu", ResourceType:=GetType(Resource))>
    Public Property PiecesJointesId As Long?
    Public Overridable Property LesPiecesJointes As ICollection(Of SelectListItem)
    Public Overridable Property PiecesJointes As ICollection(Of PieceJointe)

    Public Sub New()
    End Sub

    Public Sub New(entity As Demande)
        With Me
            .Id = entity.Id
            .CollectiviteSinistree = entity.CollectiviteSinistree
            .CollectiviteSinistreeId = entity.CollectiviteSinistreeId
            .Sinistrer = entity.Sinistrer
            .Observation = entity.Observation
            .SinistrerId = entity.SinistrerId
            .AnneeBudgetaire = entity.AnneeBudgetaire
            .AnneeBudgetaireId = entity.AnneeBudgetaireId
            .Reference = entity.Reference
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .DateDeclaration = entity.DateDeclaration
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As Demande
        Dim entity As New Demande
        With entity
            .Id = Id
            .CollectiviteSinistreeId = CollectiviteSinistreeId
            .AnneeBudgetaireId = AnneeBudgetaireId
            .SinistrerId = SinistrerId
            .Reference = Reference
            .Observation = Observation
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .DateDeclaration = DateDeclaration
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class

