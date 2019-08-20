
Partial Public Class TypeAbris
    Public Sub New()
        Abris = New HashSet(Of Abris)()
    End Sub

    Public Property Id As Long

    Public Property Libelle As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Abris As ICollection(Of Abris)
End Class