
Partial Public Class Region
    Inherits Collectivite

    Public Sub New()
        Departement = New HashSet(Of Departement)()
        User = New HashSet(Of ApplicationUser)()
    End Sub

    Public Property ChefLieu As String

    Public Overridable Property Departement As ICollection(Of Departement)
    Public Overridable Property User As ICollection(Of ApplicationUser)
End Class
