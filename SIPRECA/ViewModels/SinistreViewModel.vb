Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class SinistreViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Libelle", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Libelle As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="LieuDuSinistre", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property LieuDuSinistre As String

    <Display(Name:="DateDuSinistre", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateDuSinistre As Date = Now

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="SinistreTypeSinistre", ResourceType:=GetType(Resource))>
    Public Property TypeSinistreId As Long
    Public Overridable Property LesTypeSinistres As ICollection(Of SelectListItem)
    Public Overridable Property TypeSinistre As TypeSinistre

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

    Public Sub New(entity As Sinistre)
        With Me
            .Id = entity.Id
            .Libelle = entity.Libelle
            .LieuDuSinistre = entity.LieuDuSinistre
            .StatutExistant = entity.StatutExistant
            .TypeSinistre = entity.TypeSinistre
            .TypeSinistreId = entity.TypeSinistreId
            .DateCreation = entity.DateCreation
            .DateDuSinistre = entity.DateDuSinistre
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As Sinistre
        Dim entity As New Sinistre
        With entity
            .Id = Id
            .Libelle = Libelle
            .LieuDuSinistre = LieuDuSinistre
            .TypeSinistreId = TypeSinistreId
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .DateDuSinistre = DateDuSinistre
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class
