Partial Public Class CollectiviteSinistree

    Public Sub New()
        Demande = New HashSet(Of Demande)()
    End Sub

    Public Property Id As Long
    Public Property SinistreId As Long
    Public Property CommuneId As Long
    Public Property AnneeBudgetaireId As Long
    Public Property Libelle As String
    Public Property DateSinistre As Date = Now
    Public Property StatutExistant As Short = 1
    Public Property DateCreation As DateTime = Now
    Public Property AspNetUserId As String

    'Les Clés étrangères dans CollectiviteSinistree
    Public Overridable Property Sinistre As Sinistre
    Public Overridable Property Commune As Commune
    Public Overridable Property AnneeBudgetaire As AnneeBudgetaire
    Public Overridable Property AspNetUser As ApplicationUser

    'CollectiviteSinistree En tant que clé étrangère dans d'autres tables
    Public Overridable Property Demande As ICollection(Of Demande)

End Class
