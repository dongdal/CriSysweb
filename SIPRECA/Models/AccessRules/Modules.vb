Public Class Modules
    Public Property Id As Long
    Public Property Libelle As String
    Public Property Description As String
    Public Property StatutExistant As Short = 1
    Public Property DateCreation As DateTime = Now()

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property ModuleRole As ICollection(Of ModuleRole)
    Public Overridable Property Ressource As ICollection(Of Ressource)
    Public Sub New()
        ModuleRole = New HashSet(Of ModuleRole)()
        Ressource = New HashSet(Of Ressource)()
    End Sub

End Class
