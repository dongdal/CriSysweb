
Partial Public Class TypeOrganisation
    Public Sub New()
        Oganisation = New HashSet(Of Organisation)()
    End Sub


    Public Property Id As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Oganisation As ICollection(Of Organisation)
End Class
