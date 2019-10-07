
Partial Public Class CibleCPerteBetail
    Public Property Id As Long
    Public Property PerteBetailId As Long
    Public Property CardreSendaiCibleCId As Long

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property PerteBetail As PerteBetail
    Public Overridable Property CardreSendaiCibleC As CardreSendaiCibleC
End Class
