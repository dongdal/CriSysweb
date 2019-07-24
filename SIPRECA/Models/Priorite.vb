
Partial Public Class Priorite
    Public Sub New()
        DemandeDArticle = New HashSet(Of DemandeDArticle)()
    End Sub

    Public Property Id As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property DemandeDArticle As ICollection(Of DemandeDArticle)
End Class
