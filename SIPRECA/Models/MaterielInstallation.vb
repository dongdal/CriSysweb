
Partial Public Class MaterielInstallation
    Public Property Id As Long
    Public Property InstallationId As Long
    Public Property MaterielId As Long

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Installation As Installation
    Public Overridable Property Materiel As Materiel
End Class
