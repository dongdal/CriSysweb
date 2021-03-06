
Partial Public Class Sinistre
    Public Sub New()
        Causes = New HashSet(Of Causes)()
        Enquete = New HashSet(Of Enquete)()
        Site = New HashSet(Of Site)()
        CollectiviteSinistree = New HashSet(Of CollectiviteSinistree)()
    End Sub


    Public Property Id As Long
    Public Property TypeSinistreId As Long
    Public Property LieuDuSinistre As String
    Public Property Libelle As String
    Public Property DateDuSinistre As Date
    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property Causes As ICollection(Of Causes)
    Public Overridable Property Enquete As ICollection(Of Enquete)
    Public Overridable Property TypeSinistre As TypeSinistre
    Public Overridable Property Site As ICollection(Of Site)
    Public Overridable Property CollectiviteSinistree As ICollection(Of CollectiviteSinistree)
End Class
