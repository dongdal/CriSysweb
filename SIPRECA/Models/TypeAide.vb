Public Class TypeAide
    Public Sub New()
        NatureAide = New HashSet(Of NatureAide)()
    End Sub

    Public Property Id As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property NatureAide As ICollection(Of NatureAide)
End Class
