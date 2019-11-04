
Partial Public Class Materiel
    Public Sub New()
        MaterielAbris = New HashSet(Of MaterielAbris)()
        MaterielHopitaux = New HashSet(Of MaterielHopitaux)()
        MaterielHeliport = New HashSet(Of MaterielHeliport)()
        MaterielPortDeMer = New HashSet(Of MaterielPortDeMer)()
        MaterielAeroport = New HashSet(Of MaterielAeroport)()
        MaterielBureau = New HashSet(Of MaterielBureau)()
        MaterielInstallation = New HashSet(Of MaterielInstallation)()
        MaterielEntrepots = New HashSet(Of MaterielEntrepots)()
    End Sub

    Public Property Id As Long
    Public Property Libelle As String
    Public Property Cible As Long
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property MaterielAbris As ICollection(Of MaterielAbris)
    Public Overridable Property MaterielHopitaux As ICollection(Of MaterielHopitaux)
    Public Overridable Property MaterielHeliport As ICollection(Of MaterielHeliport)
    Public Overridable Property MaterielPortDeMer As ICollection(Of MaterielPortDeMer)
    Public Overridable Property MaterielAeroport As ICollection(Of MaterielAeroport)
    Public Overridable Property MaterielInstallation As ICollection(Of MaterielInstallation)
    Public Overridable Property MaterielBureau As ICollection(Of MaterielBureau)
    Public Overridable Property MaterielEntrepots As ICollection(Of MaterielEntrepots)
End Class
