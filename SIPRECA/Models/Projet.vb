
Partial Public Class Projet
    Public Sub New()
        PersonnelProjet = New HashSet(Of PersonnelProjet)()
        PieceJointe = New HashSet(Of PieceJointe)()
        Secteur = New HashSet(Of Secteur)()
    End Sub

    Public Property Id As Long
    Public Property AdresseId As Long
    Public Property DeviseId As Long
    Public Property OganisationId As Long
    Public Property Reference As String
    Public Property Nom As String
    Public Property Description As String
    Public Property Budget As Double
    Public Property DateDebut As Date
    Public Property DateFin As Date
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Adresse As Adresse
    Public Overridable Property Devise As Devise
    Public Overridable Property Oganisation As Organisation
    Public Overridable Property PersonnelProjet As ICollection(Of PersonnelProjet)
    Public Overridable Property PieceJointe As ICollection(Of PieceJointe)
    Public Overridable Property Secteur As ICollection(Of Secteur)
End Class
