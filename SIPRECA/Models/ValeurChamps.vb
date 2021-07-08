
Partial Public Class ValeurChamps

    Public Property Id As Long

    Public Property PropositionId As Long
    Public Overridable Property Proposition As Proposition

    Public Property Valeur As String

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    'ELEMENTS DE COLLECTE

    Public Property CodeCollecte As String 'Ce champ permet de différentier les valeurs d'une collecte, et ainsi s'assurer que les valeurs enregistrées correspondent à une même collecte.
    Public Property DateSynchronisation As DateTime = Now
    Public Property DateCollecte As DateTime = Now
    Public Property StatutExistant As Short = 1
    Public Property Latitude As String = "0"
    Public Property Longitude As String = "0"

End Class
