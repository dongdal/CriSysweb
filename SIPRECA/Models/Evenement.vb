
Partial Public Class Evenement
    Public Sub New()
        FacteurEvenement = New HashSet(Of FacteurEvenement)()
        EvenementZone = New HashSet(Of EvenementZone)()
    End Sub


    Public Property Id As Long

    Public Property Libelle As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property FacteurEvenement As ICollection(Of FacteurEvenement)
    Public Overridable Property EvenementZone As ICollection(Of EvenementZone)
End Class
