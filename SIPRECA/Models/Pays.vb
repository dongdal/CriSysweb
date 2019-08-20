Imports System.ComponentModel.DataAnnotations.Schema

Public Class Pays

    Public Sub New()
        Organisation = New HashSet(Of Organisation)()
        Ville = New HashSet(Of Ville)()
    End Sub

    Public Property Id As Long

    <Index(IsUnique:=True)>
    Public Property Code As Long
    Public Property Alpha2 As String
    Public Property Alpha3 As String
    Public Property Nom_En_Gb As String
    Public Property Nom_Fr_Fr As String

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Organisation As ICollection(Of Organisation)
    Public Overridable Property Ville As ICollection(Of Ville)
End Class
