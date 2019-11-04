
Partial Public Class Champs
    Public Sub New()
        Proposition = New HashSet(Of Proposition)()
    End Sub

    Public Property Id As Long
    Public Property TypeChampsId As Long
    Public Property SectionId As Long
    Public Property Titre As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property TypeChamps As TypeChamps

    Public Overridable Property Section As Section

    Public Overridable Property Proposition As ICollection(Of Proposition)
End Class
