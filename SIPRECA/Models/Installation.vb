
Partial Public Class Installation
    Inherits Infrastructure

    Public Sub New()
        PersonnelInstallation = New HashSet(Of PersonnelInstallation)()
        MaterielInstallation = New HashSet(Of MaterielInstallation)()
    End Sub

    Public Property HeureDOuverture As TimeSpan
    Public Property HeureFermeture As TimeSpan

    Public Overridable Property PersonnelInstallation As ICollection(Of PersonnelInstallation)
    Public Overridable Property MaterielInstallation As ICollection(Of MaterielInstallation)
End Class
