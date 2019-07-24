
Partial Public Class TypeChamps
    Public Sub New()
        Champs = New HashSet(Of Champs)()
    End Sub

    Public Property Id As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Champs As ICollection(Of Champs)
End Class
