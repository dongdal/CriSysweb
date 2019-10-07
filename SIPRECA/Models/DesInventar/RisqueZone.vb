
Partial Public Class RisqueZone
    Public Property Id As Long
    Public Property RisqueId As Long
    Public Property ZoneARisqueId As Long
    Public Property NiveauDAlertId As Long

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Risque As Risque
    Public Overridable Property NiveauDAlert As NiveauDAlert
    Public Overridable Property ZoneARisque As ZoneARisque
End Class
