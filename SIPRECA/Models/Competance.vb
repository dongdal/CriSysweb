Partial Public Class Competance

    Public Property Id As Long
    Public Property PersonnelId As Long

    Public Property Libelle As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Personnel As Personnel
End Class
