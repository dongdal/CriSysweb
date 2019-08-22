
Partial Public Class Puissance
    Public Sub New()
        HopitauxPuissance = New HashSet(Of HopitauxPuissance)()
    End Sub

    Public Property Id As Long

    Public Property Libelle As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property HopitauxPuissance As ICollection(Of HopitauxPuissance)
End Class
