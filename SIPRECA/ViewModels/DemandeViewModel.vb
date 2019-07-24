Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class DemandeViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Reference", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Reference As String

    <Display(Name:="Sinistre", ResourceType:=GetType(Resource))>
    Public Property SinistreId As String
    Public Overridable Property Sinistres As ICollection(Of SelectListItem)
    Public Overridable Property Sinistre As Sinistre

    <Display(Name:="StatutExistant", ResourceType:=GetType(Resource))>
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    Public Property StatutExistant As Short = 1

    <Display(Name:="Sinistrer", ResourceType:=GetType(Resource))>
    Public Property SinistrerId As String
    Public Overridable Property Sinistrers As ICollection(Of SelectListItem)
    Public Overridable Property Sinistrer As Sinistrer

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

    Public Sub New(entity As Demande)
        With Me
            .Id = entity.Id
            .Sinistre = entity.Sinistre
            .SinistreId = entity.SinistreId
            .Sinistrer = entity.Sinistrer
            .SinistrerId = entity.SinistrerId
            .Reference = entity.Reference
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As Demande
        Dim entity As New Demande
        With entity
            .Id = Id
            .Sinistre = Sinistre
            .SinistreId = SinistreId
            .Sinistrer = Sinistrer
            .SinistrerId = SinistrerId
            .Reference = Reference
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class

