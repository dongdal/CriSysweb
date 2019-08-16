
Partial Public Class Commune
    Inherits Collectivite

    Public Sub New()
        Quartier = New HashSet(Of Quartier)()
        User = New HashSet(Of ApplicationUser)()
        CollectiviteSinistree = New HashSet(Of CollectiviteSinistree)()
    End Sub
    Public Property DepartementId As Long

    Public Overridable Property Departement As Departement

    Public Overridable Property Quartier As ICollection(Of Quartier)
    Public Overridable Property User As ICollection(Of ApplicationUser)
    Public Overridable Property CollectiviteSinistree As ICollection(Of CollectiviteSinistree)

End Class
