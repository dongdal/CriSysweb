
Partial Public Class EvenementZone
    Public Sub New()
        CardreSendaiCibleA = New HashSet(Of CardreSendaiCibleA)()
        CardreSendaiCibleB = New HashSet(Of CardreSendaiCibleB)()
        CardreSendaiCibleC = New HashSet(Of CardreSendaiCibleC)()
        CardreSendaiCibleD = New HashSet(Of CardreSendaiCibleD)()
        AutreImpactHumainEtEconomique = New HashSet(Of AutreImpactHumainEtEconomique)()
        Solution = New HashSet(Of Solution)()
    End Sub

    Public Property Id As Long
    Public Property ZoneARisqueId As Long
    Public Property EvenementId As Long

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property ZoneARisque As ZoneARisque
    Public Overridable Property Evenement As Evenement

    Public Overridable Property CardreSendaiCibleA As ICollection(Of CardreSendaiCibleA)
    Public Overridable Property CardreSendaiCibleB As ICollection(Of CardreSendaiCibleB)
    Public Overridable Property CardreSendaiCibleC As ICollection(Of CardreSendaiCibleC)
    Public Overridable Property CardreSendaiCibleD As ICollection(Of CardreSendaiCibleD)
    Public Overridable Property AutreImpactHumainEtEconomique As ICollection(Of AutreImpactHumainEtEconomique)
    Public Overridable Property Solution As ICollection(Of Solution)
End Class
