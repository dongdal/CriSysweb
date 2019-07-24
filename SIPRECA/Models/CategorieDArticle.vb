Imports System
Imports System.Collections.Generic
Imports System.Data.Entity.Spatial


Partial Public Class CategorieDArticle
    Public Sub New()
        Article = New HashSet(Of Article)()
    End Sub

    Public Property Id As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Article As ICollection(Of Article)
End Class
