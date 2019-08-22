
Imports System.ComponentModel.DataAnnotations.Schema

Partial Public Class Element

    Public Property Id As Long
    Public Property CategorieElementId As Long
    Public Property MarqueElementId As Long

    Public Property Code As String
    Public Property Nom As String
    Public Property UniteMesure As String
    Public Property ValeurParUnité As String
    Public Property Modele As String
    Public Property AnneeFabrication As Long
    Public Property Poids As Long
    Public Property Longueur As Long
    Public Property Largeur As Long
    Public Property Hauteur As Long
    Public Property Volume As Long
    Public Property PrixAchat As Double
    Public Property DeviseId As Long

    Public Overridable Property CategorieElement As CategorieElement
    Public Overridable Property MarqueElement As MarqueElement
    Public Overridable Property Devise As Devise

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser
End Class
