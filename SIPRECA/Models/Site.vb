
Partial Public Class Site
    Public Sub New()
        Zone = New HashSet(Of Zone)()
    End Sub

    Public Property Id As Long
    Public Property SinistreId As Long
    Public Property Libelle As String
    Public Property DateCreation As DateTime=Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Sinistre As Sinistre
    Public Overridable Property Zone As ICollection(Of Zone)
End Class
