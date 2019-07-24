
Partial Public Class Region
    Inherits Collectivite

    Public Sub New()
        Departement = New HashSet(Of Departement)()
    End Sub

    Public Property ChefLieu As String

    'Public Overridable Property Collectivite As Collectivite

    Public Overridable Property Departement As ICollection(Of Departement)
End Class
