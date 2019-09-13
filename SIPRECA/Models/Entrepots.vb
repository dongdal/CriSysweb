
Partial Public Class Entrepots
    Inherits Infrastructure

    Public Sub New()
        Article = New HashSet(Of Article)()
        DemandeDArticle = New HashSet(Of DemandeDArticle)()
    End Sub

    Public Property TypeEntrepotId As Long
    Public Property Capacite As Double
    Public Property CapaciteDisponible As Double

    Public Overridable Property Article As ICollection(Of Article)
    Public Overridable Property DemandeDArticle As ICollection(Of DemandeDArticle)
    Public Overridable Property TypeEntrepot As TypeEntrepot
End Class
