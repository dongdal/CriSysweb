Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class CollectiviteSinistreeViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Libelle", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Libelle As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="CollectiviteSinistreeSinistre", ResourceType:=GetType(Resource))>
    Public Property SinistreId As Long
    Public Overridable Property LesSinistres As ICollection(Of SelectListItem)
    Public Overridable Property Sinistre As Sinistre

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="CollectiviteSinistreeCollectivite", ResourceType:=GetType(Resource))>
    Public Property CollectiviteId As Long
    Public Overridable Property LesCollectivites As ICollection(Of SelectListItem)
    Public Overridable Property Collectivite As Collectivite

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="AnneeBudgetaire", ResourceType:=GetType(Resource))>
    Public Property AnneeBudgetaireId As Long
    Public Overridable Property LesAnneeBudgetaires As ICollection(Of SelectListItem)
    Public Overridable Property AnneeBudgetaire As AnneeBudgetaire

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateSinistre", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateSinistre As Date = Now

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

    Public Sub New(entity As CollectiviteSinistree)
        With Me
            .Id = entity.Id
            .Libelle = entity.Libelle
            .DateSinistre = entity.DateSinistre
            .Sinistre = entity.Sinistre
            .SinistreId = entity.SinistreId
            .Collectivite = entity.Collectivite
            .CollectiviteId = entity.CollectiviteId
            .AnneeBudgetaire = entity.AnneeBudgetaire
            .AnneeBudgetaireId = entity.AnneeBudgetaireId
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As CollectiviteSinistree
        Dim entity As New CollectiviteSinistree
        With entity
            .Id = Id
            .Libelle = Libelle
            .DateSinistre = DateSinistre
            .SinistreId = SinistreId
            .CollectiviteId = CollectiviteId
            .AnneeBudgetaireId = AnneeBudgetaireId
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class
