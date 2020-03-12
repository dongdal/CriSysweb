Public Class Actions
    Public Property Id As Long
    Public Property Libelle As String
    Public Property Description As String
    Public Property StatutExistant As Short = 1
    Public Property DateCreation As DateTime = Now()
    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property ActionSousRessources As ICollection(Of ActionSousRessource)
    Public Sub New()
        ActionSousRessources = New HashSet(Of ActionSousRessource)()
    End Sub
End Class