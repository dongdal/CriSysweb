
Partial Public Class Departement
    Inherits Collectivite

    Public Sub New()
        Commune = New HashSet(Of Commune)()
    End Sub

    Public Property ChefLieu As String
    Public Property RegionId As Long

    'Public Overridable Property Collectivite As Collectivite
    Public Overridable Property Commune As ICollection(Of Commune)
    Public Overridable Property Region As Region
End Class
