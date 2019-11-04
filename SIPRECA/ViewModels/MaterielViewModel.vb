Imports System.ComponentModel.DataAnnotations
Imports SIPRECA.My.Resources

Public Class MaterielViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Libelle", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Libelle As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Cible", ResourceType:=GetType(Resource))>
    Public Property Cible As Long

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

    Public ReadOnly Property TypeList As IEnumerable(Of SelectListItem)
        Get
            Return New List(Of SelectListItem) From {
                New SelectListItem With {
                    .Text = Resource.Hopitaux,
                    .Value = "1"
                },
                New SelectListItem With {
                    .Text = Resource.Abris,
                    .Value = "2"
                },
                New SelectListItem With {
                    .Text = Resource.Heliport,
                    .Value = "3"
                },
                New SelectListItem With {
                    .Text = Resource.PortDeMer,
                    .Value = "4"
                },
                New SelectListItem With {
                    .Text = Resource.Aeroport,
                    .Value = "5"
                },
                New SelectListItem With {
                    .Text = Resource.Bureau,
                    .Value = "6"
                },
                New SelectListItem With {
                    .Text = Resource.Instalation,
                    .Value = "7"
                },
                New SelectListItem With {
                    .Text = Resource.Entrepot,
                    .Value = "8"
                }
            }
        End Get
    End Property

    Public Sub New()
    End Sub

    Public Sub New(entity As Materiel)
        With Me
            .Id = entity.Id
            .Libelle = entity.Libelle
            .Cible = entity.Cible
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As Materiel
        Dim entity As New Materiel
        With entity
            .Id = Id
            .Libelle = Libelle
            .Cible = Cible
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function


End Class

