Public Class Collecte
    Public Sub New()
        ValeurChamps = New HashSet(Of ValeurChamps)()
    End Sub

    Public Property Id As Long

    Public Property Valeur As Long

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1
    Public Property Latitude As Double
    Public Property Longitude As Double
    Public Property LibellePosition As String

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property ValeurChamps As ICollection(Of ValeurChamps)
End Class
