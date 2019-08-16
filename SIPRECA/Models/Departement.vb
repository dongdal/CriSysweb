
Partial Public Class Departement
    Inherits Collectivite

    Public Sub New()
        Commune = New HashSet(Of Commune)()
        User = New HashSet(Of ApplicationUser)()
    End Sub

    Public Property ChefLieu As String
    Public Property RegionId As Long

    Public Overridable Property Commune As ICollection(Of Commune)
    Public Overridable Property Region As Region
    Public Overridable Property User As ICollection(Of ApplicationUser)
End Class
