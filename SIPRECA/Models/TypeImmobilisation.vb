
Partial Public Class TypeImmobilisation
    Public Sub New()
        Immobilisation = New HashSet(Of Immobilisation)()
    End Sub


    Public Property Id As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Immobilisation As ICollection(Of Immobilisation)
End Class
