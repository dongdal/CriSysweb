
Partial Public Class TypeEntrepot
    Public Sub New()
        Entrepots = New HashSet(Of Entrepots)()
    End Sub

    Public Property Id As Long

    Public Property Libelle As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Entrepots As ICollection(Of Entrepots)
End Class
