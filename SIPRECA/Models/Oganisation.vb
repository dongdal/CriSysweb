
Partial Public Class Organisation
    Public Sub New()
        Abris = New HashSet(Of Abris)()
        Bureau = New HashSet(Of Bureau)()
        Entrepots = New HashSet(Of Entrepots)()
        Installation = New HashSet(Of Installation)()
        Moyen = New HashSet(Of Moyen)()
        Personnel = New HashSet(Of Personnel)()
        Projet = New HashSet(Of Projet)()
    End Sub

    Public Property Id As Long
    Public Property TypeOrganisationId As Long
    Public Property Nom As String
    Public Property Acronyme As String
    Public Property SiteWeb As String
    Public Property Telephone As String
    Public Property Email As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Abris As ICollection(Of Abris)
    Public Overridable Property Bureau As ICollection(Of Bureau)
    Public Overridable Property Entrepots As ICollection(Of Entrepots)
    Public Overridable Property Installation As ICollection(Of Installation)
    Public Overridable Property Moyen As ICollection(Of Moyen)
    Public Overridable Property TypeOrganisation As TypeOrganisation
    Public Overridable Property Personnel As ICollection(Of Personnel)
    Public Overridable Property Projet As ICollection(Of Projet)
End Class
