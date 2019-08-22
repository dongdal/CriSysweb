
Partial Public Class UsageHumanitaire
    Public Sub New()
        Aeroport = New HashSet(Of Aeroport)()
    End Sub


    Public Property Id As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Aeroport As ICollection(Of Aeroport)
End Class
