Imports System.Data.Entity.Spatial

Partial Public Class Adresse
    Public Sub New()
        Bureau = New HashSet(Of Bureau)()
        Entrepots = New HashSet(Of Entrepots)()
        Installation = New HashSet(Of Installation)()
        Projet = New HashSet(Of Projet)()
    End Sub

    Public Property Id As Long

    Public Property CollectiviteId As Long
    Public Property Libelle As String
    Public Property Location As DbGeography
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Overridable Property Collectivite As Collectivite

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Bureau As ICollection(Of Bureau)
    Public Overridable Property Entrepots As ICollection(Of Entrepots)
    Public Overridable Property Installation As ICollection(Of Installation)
    Public Overridable Property Projet As ICollection(Of Projet)
End Class
