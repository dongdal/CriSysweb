
Partial Public Class Devise
    Public Sub New()
        Projet = New HashSet(Of Projet)()
    End Sub

    Public Property Id As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Projet As ICollection(Of Projet)
End Class
