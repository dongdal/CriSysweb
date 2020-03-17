Imports System.ComponentModel.DataAnnotations
Imports SIPRECA
Imports SIPRECA.My.Resources

Public Class AccessRightsManagerViewModel
    Private _db As New ApplicationDbContext
    Public Property Db As ApplicationDbContext
        Get
            Return _db
        End Get
        Set(value As ApplicationDbContext)
            _db = value
        End Set
    End Property

    Public Property Id As Long

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="ModuleRole", ResourceType:=GetType(Resource))>
    Public Property ModuleRoleId As Long
    Public Overridable Property LesModuleRoles As ICollection(Of ModuleRole)
    Public Overridable Property ModuleRole As ModuleRole

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Ressource", ResourceType:=GetType(Resource))>
    Public Property RessourceId As Long
    Public Overridable Property LesRessources As ICollection(Of Ressource)
    Public Overridable Property Ressource As Ressource

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="SousRessource", ResourceType:=GetType(Resource))>
    Public Property SousRessourceId As Long
    Public Overridable Property LesSousRessources As ICollection(Of SelectListItem)
    Public Overridable Property SousRessource As SousRessource

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    '<Display(Name:="Actions", ResourceType:=GetType(Resource))>
    'Public Property ActionsId As List(Of Long)
    'Public Overridable Property LesActions As ICollection(Of SelectListItem)
    'Public Overridable Property Actions As Actions

    <Display(Name:="Utilisateur", ResourceType:=GetType(Resource))>
    Public Property SelectedAspNetUserId As String


    Public Sub New()
    End Sub

End Class
