Public Class Indemnisation

    Public Sub New()
        DetailsIndemnisation = New HashSet(Of DetailsIndemnisation)()
    End Sub

    Public Property Id As Long
    Public Property DemandeId As Long
    Public Overridable Property Demande As Demande
    Public Property Libelle As String
    Public Property Description As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property DetailsIndemnisation As ICollection(Of DetailsIndemnisation)
End Class
