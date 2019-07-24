
Partial Public Class TypeSuivi
    Public Sub New()
        Suivi = New HashSet(Of Suivi)()
    End Sub

    Public Property Id As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Suivi As ICollection(Of Suivi)
End Class
