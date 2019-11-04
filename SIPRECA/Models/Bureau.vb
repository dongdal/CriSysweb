
Partial Public Class Bureau
    Inherits Infrastructure

    Public Sub New()
        PersonnelBureau = New HashSet(Of PersonnelBureau)()
        MaterielBureau = New HashSet(Of MaterielBureau)()
    End Sub

    Public Property TypeOfficeId As Long

    Public Overridable Property TypeOffice As TypeOffice
    Public Overridable Property PersonnelBureau As ICollection(Of PersonnelBureau)
    Public Overridable Property MaterielBureau As ICollection(Of MaterielBureau)
End Class
