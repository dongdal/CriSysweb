
Partial Public Class TypeOffice
    Public Sub New()
        Bureau = New HashSet(Of Bureau)()
    End Sub


    Public Property Id As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Bureau As ICollection(Of Bureau)
End Class
