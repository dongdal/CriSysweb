Imports System.Data.Entity.Spatial

Partial Public Class DesagregationRecoltesAgricole
    Public Sub New()
        CibleCDesagregationAgricole = New HashSet(Of CibleCDesagregationAgricole)()
    End Sub

    Public Property Id As Long
    Public Property Libellle As String

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property CibleCDesagregationAgricole As ICollection(Of CibleCDesagregationAgricole)
End Class
