Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Spatial
Imports SIPRECA.My.Resources

Public Class ElementViewModel
    Public Property Id As Long

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Nom", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Nom As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Code", ResourceType:=GetType(Resource))>
    <StringLength(5, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Code As String

    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    <Display(Name:="UniteMesure", ResourceType:=GetType(Resource))>
    Public Property UniteMesure As String

    <Display(Name:="ValeurParUnite", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property ValeurParUnité As String

    <Display(Name:="Modele", ResourceType:=GetType(Resource))>
    <StringLength(250, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property Modele As String

    <Display(Name:="Longueur", ResourceType:=GetType(Resource))>
    Public Property Longueur As Long

    <Display(Name:="Largeur", ResourceType:=GetType(Resource))>
    Public Property Largeur As Long

    <Display(Name:="AnneeFabrication", ResourceType:=GetType(Resource))>
    Public Property AnneeFabrication As Long

    <Display(Name:="Poids", ResourceType:=GetType(Resource))>
    Public Property Poids As Long

    <Display(Name:="Hauteur", ResourceType:=GetType(Resource))>
    Public Property Hauteur As Long

    <Display(Name:="PrixAchat", ResourceType:=GetType(Resource))>
    Public Property PrixAchat As Long

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

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="CategorieElement", ResourceType:=GetType(Resource))>
    Public Property CategorieElementId As Long
    Public Overridable Property LesCategorieElements As ICollection(Of SelectListItem)
    Public Overridable Property CategorieElement As CategorieElement

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="MarqueElement", ResourceType:=GetType(Resource))>
    Public Property MarqueElementId As Long
    Public Overridable Property LesMarqueElements As ICollection(Of SelectListItem)
    Public Overridable Property MarqueElement As MarqueElement

    <Display(Name:="Devise", ResourceType:=GetType(Resource))>
    Public Property DeviseId As Long
    Public Overridable Property LesDevises As ICollection(Of SelectListItem)
    Public Overridable Property Devise As Devise

    Public Sub New()
    End Sub

    Public Sub New(entity As Element)
        With Me
            .Id = entity.Id
            .Nom = entity.Nom
            .Code = entity.Code
            .UniteMesure = entity.UniteMesure
            .ValeurParUnité = entity.ValeurParUnité
            .Modele = entity.Modele
            .AnneeFabrication = entity.AnneeFabrication
            .Poids = entity.Poids
            .Longueur = entity.Longueur
            .Largeur = entity.Largeur
            .Hauteur = entity.Hauteur
            .PrixAchat = entity.PrixAchat
            .DeviseId = entity.DeviseId
            .Devise = entity.Devise
            .CategorieElementId = entity.CategorieElementId
            .CategorieElement = entity.CategorieElement
            .MarqueElementId = entity.MarqueElementId
            .MarqueElement = entity.MarqueElement
            .StatutExistant = entity.StatutExistant
            .DateCreation = entity.DateCreation
            .AspNetUser = entity.AspNetUser
            .AspNetUserId = entity.AspNetUserId
        End With
    End Sub

    Public Function GetEntity() As Element
        Dim entity As New Element
        With entity
            .Id = Id
            .Nom = Nom
            .Code = Code
            .UniteMesure = UniteMesure
            .ValeurParUnité = ValeurParUnité
            .Modele = Modele
            .AnneeFabrication = AnneeFabrication
            .Poids = Poids
            .Longueur = Longueur
            .Largeur = Largeur
            .Hauteur = Hauteur
            .PrixAchat = PrixAchat
            .DeviseId = DeviseId
            .Devise = Devise
            .CategorieElementId = CategorieElementId
            .CategorieElement = CategorieElement
            .MarqueElementId = MarqueElementId
            .MarqueElement = MarqueElement
            .StatutExistant = StatutExistant
            .DateCreation = DateCreation
            .AspNetUserId = AspNetUserId
        End With
        Return entity
    End Function

End Class

