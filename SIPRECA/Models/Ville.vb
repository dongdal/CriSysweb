Public Class Ville
    Public Sub New()
        Organisation = New HashSet(Of Organisation)()
    End Sub

    Public Property Id As Long
    Public Property PaysId As Long
    Public Overridable Property Pays As Pays

    Public Property Libelle As String

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser


    Public Overridable Property Organisation As ICollection(Of Organisation)
End Class
