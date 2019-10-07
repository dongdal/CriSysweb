
Partial Public Class TypeSolution
    Public Sub New()
        Solution = New HashSet(Of Solution)()
    End Sub

    Public Property Id As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Solution As ICollection(Of Solution)
End Class
