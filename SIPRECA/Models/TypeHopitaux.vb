
Partial Public Class TypeHopitaux
    Public Sub New()
        Hopitaux = New HashSet(Of Hopitaux)()
    End Sub

    Public Property Id As Long

    Public Property Libelle As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Hopitaux As ICollection(Of Hopitaux)
End Class
