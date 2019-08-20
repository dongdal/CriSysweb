
Partial Public Class Secteur
    Public Sub New()
        Projet = New HashSet(Of Projet)()
        Organisation = New HashSet(Of Organisation)()
    End Sub

    Public Property Id As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Projet As ICollection(Of Projet)
    Public Overridable Property Organisation As ICollection(Of Organisation)
End Class
