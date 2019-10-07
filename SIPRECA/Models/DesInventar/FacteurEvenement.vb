
Partial Public Class FacteurEvenement
    Public Property Id As Long
    Public Property FacteurId As Long
    Public Property EvenementId As Long

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Facteur As Facteur
    Public Overridable Property Evenement As Evenement
End Class
