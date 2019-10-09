Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class SolutionViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Libelle", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Libelle As String

    <Display(Name:="Description", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Description As String

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

    <Display(Name:="TypeSolution", ResourceType:=GetType(Resource))>
    Public Property TypeSolutionId As String
    Public Overridable Property LesTypeSolutions As ICollection(Of SelectListItem)
    Public Overridable Property TypeSolution As TypeSolution

    <Display(Name:="EvenementZone", ResourceType:=GetType(Resource))>
    Public Property EvenementZoneId As String
    Public Overridable Property LesEvenementZones As ICollection(Of SelectListItem)
    Public Overridable Property EvenementZone As EvenementZone

    Public Sub New()
    End Sub

    Public Sub New(entity As Solution)
        With Me
            .Id = entity.Id
            .Libelle = entity.Libelle
            .Description = entity.Description
            .TypeSolution = entity.TypeSolution
            .TypeSolutionId = entity.TypeSolutionId
            .EvenementZone = entity.EvenementZone
            .EvenementZoneId = entity.EvenementZoneId
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As Solution
        Dim entity As New Solution
        With entity
            .Id = Id
            .Libelle = Libelle
            .Description = Description
            .EvenementZoneId = EvenementZoneId
            .TypeSolutionId = TypeSolutionId
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class

