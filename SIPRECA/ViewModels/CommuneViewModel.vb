Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class CommuneViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Libelle", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Libelle As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Code", ResourceType:=GetType(Resource))>
    <StringLength(100, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Code As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <RegularExpression("^(\d+(((\,))\d+)?)$", ErrorMessageResourceName:="DecimalType", ErrorMessageResourceType:=GetType(Resource))>
    <Display(Name:="Superficie", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Superficie As String = "0"

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <RegularExpression("^(\d+(((\,))\d+)?)$", ErrorMessageResourceName:="DecimalType", ErrorMessageResourceType:=GetType(Resource))>
    <Display(Name:="Population", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Population As String = "0"

    <Display(Name:="StatutExistant", ResourceType:=GetType(Resource))>
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    Public Property StatutExistant As Short = 1

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Departement", ResourceType:=GetType(Resource))>
    Public Property DepartementId As Long
    Public Overridable Property Departements As ICollection(Of SelectListItem)
    Public Overridable Property Departement As Departement

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateCreation", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateCreation As DateTime = Now

    <Display(Name:="Utilisateur", ResourceType:=GetType(Resource))>
    Public Property AspNetUserId As String
    Public Overridable Property LesUtilisateurs As ICollection(Of SelectListItem)
    Public Overridable Property AspNetUser As ApplicationUser

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Longitude", ResourceType:=GetType(Resource))>
    Public Property Longitude As Double?

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Latitude", ResourceType:=GetType(Resource))>
    Public Property Latitude As Double?


    Public Sub New()
    End Sub

    Public Sub New(entity As Commune)
        With Me
            .Id = entity.Id
            .Code = entity.Code
            .Departement = entity.Departement
            .DepartementId = entity.DepartementId
            .Libelle = entity.Libelle
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .StatutExistant = entity.StatutExistant
            .Latitude = entity.Latitude
            .Longitude = entity.Longitude
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As Commune
        Dim entity As New Commune
        With entity
            .Id = Id
            .Code = Code
            .DepartementId = DepartementId
            .Libelle = Libelle
            .StatutExistant = StatutExistant
            .Superficie = Superficie
            .Population = Population
            .Longitude = Longitude
            .Latitude = Latitude
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class

