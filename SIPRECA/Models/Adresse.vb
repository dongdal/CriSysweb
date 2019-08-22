Imports System.Data.Entity.Spatial

Partial Public Class Adresse
    Public Sub New()
        Infrastructure = New HashSet(Of Infrastructure)()
        Projet = New HashSet(Of Projet)()
    End Sub

    Public Property Id As Long

    Public Property VilleId As Long
    Public Property Libelle As String
    Public Property Location As DbGeography
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Overridable Property Ville As Ville

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Infrastructure As ICollection(Of Infrastructure)
    Public Overridable Property Projet As ICollection(Of Projet)
End Class
