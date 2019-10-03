Public Class Quartier
    Inherits Collectivite
    Public Sub New()
        ZoneLocalisation = New HashSet(Of ZoneLocalisation)()
    End Sub

    Public Property CommuneId As Long
    Public Overridable Property Commune As Commune
    Public Overridable Property ZoneLocalisation As ICollection(Of ZoneLocalisation)
End Class
