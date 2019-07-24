Partial Public Class Indemmisation

    Public Property Id As Long
    Public Property DemandeId As Long
    Public Property CollectiviteId As Long
    Public Property Montant As Double
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Collectivite As Collectivite
    Public Overridable Property Demande As Demande
End Class
