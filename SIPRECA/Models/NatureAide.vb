Public Class NatureAide
    Public Sub New()
        Indemnisation = New HashSet(Of Indemnisation)()
    End Sub

    Public Property Id As Long
    Public Property TypeAideId As Long
    Public Overridable Property TypeAide As TypeAide
    Public Property Libelle As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Indemnisation As ICollection(Of Indemnisation)
End Class
