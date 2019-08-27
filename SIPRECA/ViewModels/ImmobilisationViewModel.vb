Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class ImmobilisationViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="NumeroImobilisation", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property NumeroImobilisation As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="NumeroDeSerie", ResourceType:=GetType(Resource))>
    <StringLength(5, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property NumeroDeSerie As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateAchat", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateAchat As Date

    <Display(Name:="PrixAchat", ResourceType:=GetType(Resource))>
    Public Property PrixAchat As Double

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Fournisseur", ResourceType:=GetType(Resource))>
    Public Property FournisseurId As Long
    Public Overridable Property LesFournisseurs As ICollection(Of SelectListItem)
    Public Overridable Property Fournisseur As Organisation

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="TypeImmobilisation", ResourceType:=GetType(Resource))>
    Public Property TypeImmobilisationId As Long
    Public Overridable Property LesTypeImmobilisations As ICollection(Of SelectListItem)
    Public Overridable Property TypeImmobilisation As TypeImmobilisation

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Infrastructure", ResourceType:=GetType(Resource))>
    Public Property InfrastructureId As Long
    Public Overridable Property LesInfrastructures As ICollection(Of SelectListItem)
    Public Overridable Property Infrastructure As Infrastructure

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Devise", ResourceType:=GetType(Resource))>
    Public Property DeviseId As Long
    Public Overridable Property LesDevises As ICollection(Of SelectListItem)
    Public Overridable Property Devise As Devise

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Element", ResourceType:=GetType(Resource))>
    Public Property ElementId As Long
    Public Overridable Property LesElements As ICollection(Of SelectListItem)
    Public Overridable Property Element As Element

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

    Public Sub New(entity As Immobilisation)
        With Me
            .Id = entity.Id
            .NumeroImobilisation = entity.NumeroImobilisation
            .NumeroDeSerie = entity.NumeroDeSerie
            .DateAchat = entity.DateAchat
            .PrixAchat = entity.PrixAchat
            .TypeImmobilisationId = entity.TypeImmobilisationId
            .TypeImmobilisation = entity.TypeImmobilisation
            .InfrastructureId = entity.InfrastructureId
            .Infrastructure = entity.Infrastructure
            .Fournisseur = entity.Fournisseur
            .FournisseurId = entity.FournisseurId
            .ElementId = entity.ElementId
            .Element = entity.Element
            .DeviseId = entity.DeviseId
            .Devise = entity.Devise
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As Immobilisation
        Dim entity As New Immobilisation
        With entity
            .Id = Id
            .NumeroImobilisation = NumeroImobilisation
            .NumeroDeSerie = NumeroDeSerie
            .DateAchat = DateAchat
            .PrixAchat = PrixAchat
            .TypeImmobilisationId = TypeImmobilisationId
            .InfrastructureId = entity.InfrastructureId
            .FournisseurId = FournisseurId
            .ElementId = ElementId
            .DeviseId = DeviseId
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function

End Class

