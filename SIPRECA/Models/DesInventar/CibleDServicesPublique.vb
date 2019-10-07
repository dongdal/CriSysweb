
Partial Public Class CibleDServicesPublique
    Public Property Id As Long
    Public Property ServicesPubliquePertubeId As Long
    Public Property CardreSendaiCibleDId As Long

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property ServicesPubliquePertube As ServicesPubliquePertube
    Public Overridable Property CardreSendaiCibleD As CardreSendaiCibleD
End Class
