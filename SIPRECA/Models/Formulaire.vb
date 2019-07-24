
Partial Public Class Formulaire
    Public Sub New()
        Section = New HashSet(Of Section)()
    End Sub


    Public Property Id As Long

    Public Property EnqueteId As Long
    Public Property Titre As String
    Public Property Description As String
    Public Property StatutExistant As Short=1
    Public Property DateCreation As DateTime=Now

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Enquete As Enquete

    Public Overridable Property Section As ICollection(Of Section)
End Class
