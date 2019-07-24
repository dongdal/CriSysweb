
Partial Public Class Causes

    Public Property Id As Long

    Public Property SinistreId As Long
    Public Property Libelle As String
    Public Property Description As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Sinistre As Sinistre
End Class
