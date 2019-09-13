Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class VilleViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Libelle", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Libelle As String

    <Display(Name:="StatutExistant", ResourceType:=GetType(Resource))>
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    Public Property StatutExistant As Short = 1

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateCreation", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateCreation As DateTime = Now

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Pays", ResourceType:=GetType(Resource))>
    Public Property PaysId As Long
    Public Overridable Property LesPays As ICollection(Of SelectListItem)
    Public Overridable Property Pays As Pays

    <Display(Name:="Utilisateur", ResourceType:=GetType(Resource))>
    Public Property AspNetUserId As String
    Public Overridable Property LesUtilisateurs As ICollection(Of SelectListItem)
    Public Overridable Property AspNetUser As ApplicationUser

    Public Sub New()
    End Sub

    Public Sub New(entity As Ville)
        With Me
            .Id = entity.Id
            .Libelle = entity.Libelle
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .PaysId = entity.PaysId
            .Pays = entity.Pays
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As Ville
        Dim entity As New Ville
        With entity
            .Id = Id
            .Libelle = Libelle
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
            .PaysId = PaysId
        End With
        Return entity
    End Function


End Class

