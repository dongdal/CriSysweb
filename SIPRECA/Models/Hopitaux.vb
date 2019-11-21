
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Hopitaux
    Public Sub New()
        HopitauxPuissance = New HashSet(Of HopitauxPuissance)()
        MaterielHopitaux = New HashSet(Of MaterielHopitaux)()
    End Sub


    Public Property Id As Long
    Public Property OganisationId As Long
    Public Property TypeHopitauxId As Long
    Public Property CommuneId As Long?


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
    Public Property Location As DbGeometry

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser


    Public Overridable Property Commune As Commune
    Public Overridable Property TypeHopitaux As TypeHopitaux
    Public Overridable Property Oganisation As Organisation

    Public Overridable Property HopitauxPuissance As ICollection(Of HopitauxPuissance)
    Public Overridable Property MaterielHopitaux As ICollection(Of MaterielHopitaux)
End Class
