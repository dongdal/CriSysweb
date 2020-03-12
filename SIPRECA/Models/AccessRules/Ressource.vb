Public Class Ressource
    Public Property Id As Long
    Public Property ModulesId As Long
    Public Overridable Property Modules As Modules
    Public Property Libelle As String
    Public Property Description As String
    Public Property StatutExistant As Short = 1
    Public Property DateCreation As DateTime = Now()
    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property SousRessource As ICollection(Of SousRessource)
    Public Sub New()
        SousRessource = New HashSet(Of SousRessource)()
    End Sub

End Class