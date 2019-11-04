
Partial Public Class ValeurChamps

    Public Property Id As Long

    Public Property PropositionId As Long
    Public Overridable Property Proposition As Proposition

    Public Property CollecteId As Long
    Public Overridable Property Collecte As Collecte

    Public Property Valeur As String

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

End Class
