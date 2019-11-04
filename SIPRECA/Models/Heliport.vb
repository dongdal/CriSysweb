Imports System.Data.Entity.Spatial

Partial Public Class Heliport
    Public Sub New()
        MaterielHeliport = New HashSet(Of MaterielHeliport)()
    End Sub

    Public Property Id As Long
    Public Property OganisationId As Long
    Public Property VilleId As Long

    Public Property Nom As String
    Public Property Code As String
    Public Property Telephone As String
    Public Property Telephone2 As String
    Public Property SiteWeb As String
    Public Property Email As String
    Public Property Location As DbGeometry
    'Public Property Location As DbGeography

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Ville As Ville
    Public Overridable Property Oganisation As Organisation
    Public Overridable Property MaterielHeliport As ICollection(Of MaterielHeliport)
End Class
