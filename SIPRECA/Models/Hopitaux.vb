
Imports System.ComponentModel.DataAnnotations.Schema

Partial Public Class Hopitaux
    Public Sub New()

        HopitauxPuissance = New HashSet(Of HopitauxPuissance)()
    End Sub


    Public Property Id As Long
    Public Property OganisationId As Long
    Public Property TypeHopitauxId As Long
    Public Property AdresseId As Long

    Public Property Nom As String
    Public Property Code As String
    Public Property NombreDeLitMin As Long
    Public Property NombreDeLitMax As Long
    Public Property NombreDeMedecin As Long
    Public Property NombreDInfimiere As Long
    Public Property NombreDePersonnelNonMedical As Long
    Public Property Telephone As String
    Public Property TelephoneUrgence As String
    Public Property SiteWeb As String
    Public Property Email As String

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser


    Public Overridable Property Adresse As Adresse
    Public Overridable Property TypeHopitaux As TypeHopitaux
    Public Overridable Property Oganisation As Organisation

    Public Overridable Property HopitauxPuissance As ICollection(Of HopitauxPuissance)
End Class
