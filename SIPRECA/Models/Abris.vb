
Partial Public Class Abris
    Public Sub New()
        MaladieSinistre = New HashSet(Of MaladieSinistre)()
        PersonnelAbris = New HashSet(Of PersonnelAbris)()
    End Sub


    Public Property Id As Long

    Public Property OganisationId As Long
    Public Property TypeAbrisId As Long
    Public Property AdresseId As Long
    Public Property Nom As String
    Public Property EstimationPopulation As Long
    Public Property Capacite As Long

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short=1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser


    Public Overridable Property Oganisation As Organisation
    Public Overridable Property Adresse As Adresse
    Public Overridable Property TypeAbris As TypeAbris

    Public Overridable Property MaladieSinistre As ICollection(Of MaladieSinistre)
    Public Overridable Property PersonnelAbris As ICollection(Of PersonnelAbris)
End Class
