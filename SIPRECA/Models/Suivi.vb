
Partial Public Class Suivi

    Public Property Id As Long
    Public Property DemandeId As Long
    Public Property TypeSuiviId As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Demande As Demande
    Public Overridable Property TypeSuivi As TypeSuivi
End Class
