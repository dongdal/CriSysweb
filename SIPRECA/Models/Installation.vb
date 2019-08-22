
Partial Public Class Installation
    Inherits Infrastructure

    Public Sub New()
        PersonnelInstallation = New HashSet(Of PersonnelInstallation)()

    End Sub
    Public Property HeureDOuverture As DateTime
    Public Property HeureFermeture As DateTime

    Public Overridable Property PersonnelInstallation As ICollection(Of PersonnelInstallation)
End Class
