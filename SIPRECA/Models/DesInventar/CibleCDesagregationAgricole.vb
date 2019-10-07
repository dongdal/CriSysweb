
Partial Public Class CibleCDesagregationAgricole
    Public Property Id As Long
    Public Property DesagregationRecoltesAgricoleId As Long
    Public Property CardreSendaiCibleCId As Long

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property DesagregationRecoltesAgricole As DesagregationRecoltesAgricole
    Public Overridable Property CardreSendaiCibleC As CardreSendaiCibleC
End Class
