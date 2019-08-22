
Partial Public Class PersonnelInstallation
    Public Property Id As Long
    Public Property PersonnelId As Long
    Public Property InstallationId As Long

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Property TitreDuPoste As String

    Public Overridable Property Personnel As Personnel
    Public Overridable Property Installation As Installation
End Class
