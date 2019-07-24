
Partial Public Class ValeurChamps

    Public Property Id As Long
    Public Property ChampsSectionId As Long
    Public Property Valeur As String

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property ChampsSection As ICollection(Of ChampsSection)

End Class
