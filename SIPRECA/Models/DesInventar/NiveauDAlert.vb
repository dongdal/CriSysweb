
Partial Public Class NiveauDAlert
    Public Sub New()
        RisqueZone = New HashSet(Of RisqueZone)()
    End Sub

    Public Property Id As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property RisqueZone As ICollection(Of RisqueZone)
End Class
