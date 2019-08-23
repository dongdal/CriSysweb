
Partial Public Class Organisation
    Public Sub New()
        Abris = New HashSet(Of Abris)()
        Infrastructure = New HashSet(Of Infrastructure)()
        Moyen = New HashSet(Of Moyen)()
        Personnel = New HashSet(Of Personnel)()
        Projet = New HashSet(Of Projet)()
        Hopitaux = New HashSet(Of Hopitaux)()
    End Sub

    Public Property Id As Long
    Public Property TypeOrganisationId As Long
    Public Property Nom As String
    Public Property Acronyme As String
    Public Property SiteWeb As String
    Public Property Telephone As String
    Public Property Email As String
    Public Property BoitePostale As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Property VilleId As Long
    Public Overridable Property Ville As Ville

    Public Overridable Property Abris As ICollection(Of Abris)
    Public Overridable Property Infrastructure As ICollection(Of Infrastructure)
    Public Overridable Property Moyen As ICollection(Of Moyen)
    Public Overridable Property TypeOrganisation As TypeOrganisation
    Public Overridable Property Personnel As ICollection(Of Personnel)
    Public Overridable Property Projet As ICollection(Of Projet)
    Public Overridable Property Hopitaux As ICollection(Of Hopitaux)
End Class
