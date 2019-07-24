
Partial Public Class DemandeDArticle
    Public Sub New()
        DemandeArticle = New HashSet(Of DemandeArticle)()
    End Sub

    Public Property Id As Long
    Public Property PersonnelId As Long
    Public Property EntrepotsId As Long
    Public Property PrioriteId As Long
    Public Property Code As String
    Public Property Details As String
    Public Property DateCreation As DateTime=Now
    Public Property DatePrevuDeReception As DateTime
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property DemandeArticle As ICollection(Of DemandeArticle)

    Public Overridable Property Entrepots As Entrepots
    Public Overridable Property Personnel As Personnel
    Public Overridable Property Priorite As Priorite

End Class
