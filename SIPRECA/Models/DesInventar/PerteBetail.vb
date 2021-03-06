Imports System.Data.Entity.Spatial

Partial Public Class PerteBetail
    Public Sub New()
        CibleCPerteBetail = New HashSet(Of CibleCPerteBetail)()
    End Sub

    Public Property Id As Long
    Public Property Libelle As String

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property CibleCPerteBetail As ICollection(Of CibleCPerteBetail)
End Class
