
Partial Public Class ZoneLocalisation

    Public Property Id As Long
    Public Property ZoneARisqueId As Long
    Public Property QuartierId As Long

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property ZoneARisque As ZoneARisque
    Public Overridable Property Quartier As Quartier
End Class
