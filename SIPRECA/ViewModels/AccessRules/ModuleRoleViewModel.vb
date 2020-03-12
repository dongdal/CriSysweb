Imports System.ComponentModel.DataAnnotations
Imports Microsoft.AspNet.Identity.EntityFramework
Imports SIPRECA.My.Resources

Public Class ModuleRoleViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Modules", ResourceType:=GetType(Resource))>
    Public Property ModulesId As Long
    Public Overridable Property LesModules As ICollection(Of SelectListItem)
    Public Overridable Property Modules As Modules

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Role", ResourceType:=GetType(Resource))>
    Public Property AspNetRolesId As String
    Public Overridable Property LesRoles As ICollection(Of SelectListItem)
    Public Overridable Property AspNetRoles As IdentityRole

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

    Public Sub New(entity As ModuleRole)
        With Me
            .Id = entity.Id
            .ModulesId = entity.ModulesId
            .Modules = entity.Modules
            .AspNetRolesId = entity.AspNetRolesId
            .AspNetRoles = entity.AspNetRoles
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As ModuleRole
        Dim entity As New ModuleRole
        With entity
            .Id = Id
            .ModulesId = ModulesId
            .AspNetRolesId = AspNetRolesId
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class

