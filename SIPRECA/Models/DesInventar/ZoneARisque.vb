
Imports System.Data.Entity.Spatial

Partial Public Class ZoneARisque
    Public Sub New()
        EvenementZone = New HashSet(Of EvenementZone)()
        ZoneLocalisation = New HashSet(Of ZoneLocalisation)()
    End Sub

    Public Property Id As Long
    Public Property Libelle As String
    Public Property Location As DbGeometry
    Public Property Rayon As Double
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property EvenementZone As ICollection(Of EvenementZone)
    Public Overridable Property ZoneLocalisation As ICollection(Of ZoneLocalisation)
End Class
